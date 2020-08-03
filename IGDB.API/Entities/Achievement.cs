using IGDB.API.Common;
using IGDB.API.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGDB.API.Entities
{
	public class Achievement : AuditableBaseEntity
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("achievement_icon")]
		public string AchievementIconID { get; set; }
		[JsonProperty("locked_achievement_icon")]
		public string LockedAchievementIconID { get; set; }
		[JsonProperty("category")]
		public EAchievementCategory Category { get; set; }
		[JsonProperty("language")]
		public EAchievementLanguage Language { get; set; }
		[JsonProperty("rank")]
		public EAchievementRank Rank { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		public string ExternalId { get; set; }
		[JsonProperty("game")]
		public string GameId { get; set; }
		[JsonProperty("owners_percentage")]
		public double? OwnersPercentage { get; set; }
		[JsonProperty("slug")]
		public string Slug { get; set; }
		[JsonProperty("tags")]
		public IReadOnlyCollection<string> Tags { get; set; }

		public Achievement()
		{
			Tags = new List<string>();
		}
	}
}
