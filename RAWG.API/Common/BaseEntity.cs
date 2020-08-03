using Newtonsoft.Json;

namespace RAWG.API.Common
{
	public class BaseEntity
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("slug")]
		public string Slug { get; set; }
	}
}
