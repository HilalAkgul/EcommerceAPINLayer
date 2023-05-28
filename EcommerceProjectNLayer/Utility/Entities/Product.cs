using System;
using System.Text.Json.Serialization;
using Entities.Base;

namespace Entities
{
	public class Product : IBaseEntity
    {
	
		public string Name { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
     
        public ICollection<Cart> Carts { get; set; }
    }
}

