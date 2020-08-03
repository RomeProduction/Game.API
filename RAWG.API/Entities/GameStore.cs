using Newtonsoft.Json;

namespace RAWG.API.Entities
{
	public class GameStore
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("store")]
		public Store Store { get; set; }
		[JsonProperty("url_en")]
		public string UrlEn { get; set; }
		[JsonProperty("url_ru")]
		public string UrlRu { get; set; }
	}
}
