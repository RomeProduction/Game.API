using Newtonsoft.Json;
using RAWG.API.Common;

namespace RAWG.API.Entities
{
	public class Genre : BaseEntity
	{
		[JsonProperty("games_count")]
		public int? GamesCount { get; set; }
		[JsonProperty("image_background")]
		public string BackgroundImageUrl { get; set; }
	}
}
