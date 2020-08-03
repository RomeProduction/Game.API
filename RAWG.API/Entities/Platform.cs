using Newtonsoft.Json;
using RAWG.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAWG.API.Entities
{
	public class Platform : BaseEntity
	{
		[JsonProperty("image_background")]
		public string BackgroundImageUrl { get; set; }
		[JsonProperty("year_start")]
		public int? YearStart { get; set; }
		[JsonProperty("year_end")]
		public int? YearEnd { get; set; }
		[JsonProperty("games_count")]
		public int? GamesCount { get; set; }
	}
}
