using IGDB.API.Common;
using IGDB.API.Enums;
using Newtonsoft.Json;

namespace IGDB.API.Entities
{
	public class AgeRatingContentDescription : BaseEntity
	{
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("category")]
		public EAgeRatingContentCategory Category { get; set; }
	}
}
