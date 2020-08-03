using Newtonsoft.Json;
using RAWG.API.Common;
using System.Collections.Generic;

namespace RAWG.API.Entities
{
	public class ParentPlatform : BaseEntity
	{
		[JsonProperty("platforms")]
		public IReadOnlyCollection<Platform> Platforms { get; set; }

		public ParentPlatform()
		{
			Platforms = new List<Platform>();
		}
	}
}
