using Newtonsoft.Json;
using RAWG.API.Common;
using System;
using System.Collections.Generic;

namespace RAWG.API.Entities
{
	public class Game : BaseEntity
	{
		[JsonProperty("released")]
		public DateTime? Released { get; set; }
		[JsonProperty("tba")]
		public bool Tba { get; set; }
		[JsonProperty("background_image")]
		public string BackgroundImage { get; set; }
		[JsonProperty("rating")]
		public double? Rating { get; set; }
		[JsonProperty("rating_top")]
		public string RatingTop { get; set; }
		[JsonProperty("ratings_count")]
		public int? RatingsCount { get; set; }
		[JsonProperty("reviews_text_count")]
		public int? ReviewsTextCount { get; set; }
		[JsonProperty("metacritic")]
		public double? Metacritic { get; set; }
		[JsonProperty("playtime")]
		public double? Playtime { get; set; }

		[JsonProperty("ratings")]
		public IReadOnlyCollection<Rating> Ratings { get; set; }
		[JsonProperty("parent_platforms")]
		public IReadOnlyCollection<ParentPlatform> ParentPlatforms { get; set; }
		[JsonProperty("genres")]
		public IReadOnlyCollection<Genre> Genres { get; set; }
		[JsonProperty("stores")]
		public IReadOnlyCollection<GameStore> Stores { get; set; }

		public Game()
		{
			Ratings = new List<Rating>();
			ParentPlatforms = new List<ParentPlatform>();
			Genres = new List<Genre>();
			Stores = new List<GameStore>();
		}
	}
}
