using IGDB.API.Common;
using Newtonsoft.Json;

namespace IGDB.API.Entities
{
	public class Keyword : AuditableBaseEntity
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("slug")]
		public string Slug { get; set; }
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
