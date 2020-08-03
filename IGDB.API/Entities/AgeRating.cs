using IGDB.API.Common;
using IGDB.API.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGDB.API.Entities
{
	public class AgeRating : BaseEntity
	{
		[JsonProperty("category")]
		public EAgeCategory Category { get; set; }
		[JsonProperty("rating")]
		public EAgeRating Rating { get; set; }
		[JsonProperty("rating_cover_url")]
		public string RatingCoverUrl { get; set; }
		[JsonProperty("synopsis")]
		public string Synopsis { get; set; }
	}
}
