using Newtonsoft.Json;
using RAWG.API.Common;

namespace RAWG.API.Entities
{
	public class Store : BaseEntity
	{
		[JsonProperty("domain")]
		public string Domain { get; set; }
		[JsonProperty("image_background")]
		public string BackgroundImageUrl { get; set; }
		[JsonProperty("games_count")]
		public int? GamesCount { get; set; }
	}
}
