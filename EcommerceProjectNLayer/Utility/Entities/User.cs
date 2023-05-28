using System;
using Entities.Base;

namespace Entities
{
	public class User : IBaseEntity
    {
		public string UserName { get; set; }
		public string Password { get; set; }

        public ICollection<Cart> Carts { get; set; }
    }
}

