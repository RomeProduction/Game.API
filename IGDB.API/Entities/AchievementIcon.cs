using IGDB.API.Common;
using Newtonsoft.Json;

namespace IGDB.API.Entities
{
	public class AchievementIcon : BaseEntity
	{
		[JsonProperty("height")]
		public int? Height { get; set; }
		[JsonProperty("width")]
		public int? Width { get; set; }
		[JsonProperty("url")]
		public string Url { get; set; }
		[JsonProperty("image_id")]
		public string ImageId { get; set; }
	}
}
