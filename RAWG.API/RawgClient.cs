using RAWG.API.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using RAWG.API.Models;

namespace RAWG.API
{
	public class RawgClient
	{
		private readonly string _userAgent;

		public RawgClient(string userAgent)
		{
			if (string.IsNullOrEmpty(userAgent) || string.IsNullOrWhiteSpace(userAgent))
			{
				throw new ArgumentNullException("UserAgent is empty");
			}
			_userAgent = userAgent;
		}

		public IEnumerable<Game> GetGames()
		{
			const string endpoint = RawgConstants.RawgEndpoints.Games;

			var list = RequestWithPagination<Game>(endpoint);
			return list;
		}

		public IEnumerable<Genre> GetGenres()
		{
			const string endpoint = RawgConstants.RawgEndpoints.Genres;

			var list = RequestWithPagination<Genre>(endpoint);
			return list;
		}

		public IEnumerable<Store> GetStores()
		{
			const string endpoint = RawgConstants.RawgEndpoints.Stores;

			var list = RequestWithPagination<Store>(endpoint);
			return list;
		}

		public IEnumerable<ParentPlatform> GetParentPlatforms()
		{
			const string endpoint = RawgConstants.RawgEndpoints.ParentPlatforms;

			var list = RequestWithPagination<ParentPlatform>(endpoint);
			return list;
		}

		private IEnumerable<T> RequestWithPagination<T>(string endpoint, int? count = null)
		{
			List<T> result = new List<T>();
			string nextUrl = null;
			bool isProcess = true;
			while (isProcess)
			{
				var response = Request(endpoint, nextUrl).Result;
				var strJson = response.Content.ReadAsStringAsync().Result;
				
				var rawgRespone = JsonConvert.DeserializeObject<RawgResult>(strJson);
				var entites = JsonConvert.DeserializeObject<IEnumerable<T>>(rawgRespone.Results + "");
				result.AddRange(entites);

				if (string.IsNullOrEmpty(rawgRespone.Next) || count.HasValue && count >= result.Count)
				{
					isProcess = false;
				}
				nextUrl = rawgRespone.Next;
			}

			return result;
		}
		private async Task<HttpResponseMessage> Request(string endpoint, string nextUrl = null)
		{
			try
			{
				var url = string.IsNullOrEmpty(nextUrl) ? RawgConstants.BaseUrl + $"/{endpoint}" : nextUrl;

				HttpClient client = new HttpClient();

				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

				HttpRequestMessage httpRequest = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri(url),
					Headers =
				{
					{ HttpRequestHeader.Accept.ToString(), "application/json" },
					{ "user-agent" , _userAgent},
				},
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
	}
}
