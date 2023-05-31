using System;
using System.ComponentModel.DataAnnotations;

namespace Dtos
{
	public class LoginDto
	{
		[Required]
		public string password { get; set; }
        public string userName { get; set; }
    }
}

