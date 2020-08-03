using IGDB.API.Common;
using IGDB.API.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IGDB.API.Entities
{
	public class Game : AuditableBaseEntity
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("popularity")]
		public double? Popularity { get; set; }
		[JsonProperty("rating")]
		public double? Rating { get; set; }
		[JsonProperty("rating_count")]
		public int? RatingCount { get; set; }
		[JsonProperty("total_rating")]
		public double? TotalRating { get; set; }
		[JsonProperty("total_rating_count")]
		public int? TotalRatingCount { get; set; }
		[JsonProperty("slug")]
		public string Slug { get; set; }
		[JsonProperty("storyline")]
		public string Storyline { get; set; }
		[JsonProperty("summary")]
		public string Summary { get; set; }
		[JsonProperty("url")]
		public string Url { get; set; }
		[JsonProperty("version_title")]
		public string VersionTitle { get; set; }
		public string AgeRatingId { get; set; }
		[JsonProperty("aggregated_rating")]
		public double? AggregatedRating { get; set; }
		[JsonProperty("aggregated_rating_count")]
		public int? AggregatedRatingCount { get; set; }
		[JsonProperty("category")]
		public EGameCategory Category { get; set; }
		[JsonProperty("status")]
		public EGameStatus Status { get; set; }
		[JsonProperty("alternative_names")]
		public IReadOnlyCollection<AlternativeName> AlternativeNames { get; set; }
		[JsonProperty("genres")]
		public IReadOnlyCollection<Genre> Genres { get; set; }
		[JsonProperty("keywords")]
		public IReadOnlyCollection<Keyword> Keywords { get; set; }

		public Game()
		{
			Genres = new List<Genre>();
			Keywords = new List<Keyword>();
			AlternativeNames = new List<AlternativeName>();
		}
	}
}
