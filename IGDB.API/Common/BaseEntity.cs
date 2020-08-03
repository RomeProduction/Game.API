using Newtonsoft.Json;
using System;

namespace IGDB.API.Common
{
	public class BaseEntity
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("checksum")]
		public Guid CheckSum { get; set; }
	}
}
