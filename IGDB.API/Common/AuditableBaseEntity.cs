using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace IGDB.API.Common
{
	public class AuditableBaseEntity : BaseEntity
	{
		[JsonProperty("created_at")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? DateCreate { get; set; }
		[JsonProperty("updated_at")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? DateUpdate { get; set; }
	}
}
