using IGDB.API.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace IGDB.API
{
	public class IgdbClient
	{
		private readonly string _apiKey;
		private int _limitOnPage = 100;
		public const string Version = "3.0";

		public int LimitOnPage {
			get {
				return _limitOnPage;
			}
			set {
				if(value >= IgdbConstants.MaxLimit)
				{
					throw new ArgumentOutOfRangeException($"Max allowable limit: {IgdbConstants.MaxLimit}");
				}
				_limitOnPage = value;
			}
		}
		public IgdbClient(string apiKey)
		{
			if (string.IsNullOrEmpty(apiKey) || string.IsNullOrWhiteSpace(apiKey))
			{
				throw new ArgumentNullException("ApiKey is empty");
			}
			_apiKey = apiKey;
		}

		public IEnumerable<Game> GetGames()
		{
			const string endpoint = "games";
			const string query = "fields *, genres.*, alternative_names.*, keywords.*";

			var response = Request(endpoint, query).Result;
			var strJson = response.Content.ReadAsStringAsync().Result;

			var games = JsonConvert.DeserializeObject<IEnumerable<Game>>(strJson);
			return games;
		}

		private IEnumerable<T> RequestWithPagination<T>(string endpoint, string query, int? count = null)
		{
			List<T> result = new List<T>();

			bool isProcess = true;
			while (isProcess)
			{
				var response = Request(endpoint, query).Result;
				var strJson = response.Content.ReadAsStringAsync().Result;
				if (string.IsNullOrEmpty(strJson))
				{
					break;
				}

				var entites = JsonConvert.DeserializeObject<IEnumerable<T>>(strJson);
				result.AddRange(entites);
			}

			return result;
		}
		private async Task<HttpResponseMessage> Request(string endpoint, string query, int? offset = null)
		{
			try
			{
				HttpClient client = new HttpClient();

				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

				HttpRequestMessage httpRequest = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri(IgdbConstants.BaseUrl + $"/{endpoint}"),
					Headers =
				{
					{ HttpRequestHeader.Accept.ToString(), "application/json" },
					{ "user-key" , _apiKey},
				},
					Content = new StringContent(string.Join(';', query, BuildLimit(_limitOnPage), BuildOffset(offset))),
				};

				var response = await client.SendAsync(httpRequest);
				if (response.StatusCode != HttpStatusCode.OK)
				{
					throw new Exception($"Http request failed. Code: {response.StatusCode}");
				}
				return response;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		private string BuildLimit(int? limit)
		{
			if (!limit.HasValue)
			{
				return string.Empty;
			}
			return $" limit {limit.Value}";
		}
		private string BuildOffset(int? offset)
		{
			if (!offset.HasValue)
			{
				return string.Empty;
			}
			return $" offset {offset.Value}";
		}
	}
}
