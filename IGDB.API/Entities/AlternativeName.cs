using IGDB.API.Common;
using Newtonsoft.Json;

namespace IGDB.API.Entities
{
	public class AlternativeName : BaseEntity
	{
		[JsonProperty("game")]
		public string GameId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("comment")]
		public string Comment { get; set; }
	}
}
