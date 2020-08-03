using Newtonsoft.Json;
using System.Collections.Generic;

namespace RAWG.API.Models
{
	internal class RawgResult {
		[JsonProperty("count")]
		public int Count { get; set; }
		[JsonProperty("next")]
		public string Next { get; set; }
		[JsonProperty("previous")]
		public string Previous { get; set; }
		[JsonProperty("results")]
		public object Results { get; set; }
	}
}
