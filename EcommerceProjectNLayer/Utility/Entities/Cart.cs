using System;
using System.Text.Json.Serialization;
using Entities.Base;

namespace Entities
{
	public class Cart:IBaseEntity
	{
		public int UserId { get; set; }
		public int ProductId { get; set; }
		public int Unit { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public User User { get; set; }
    }
}

