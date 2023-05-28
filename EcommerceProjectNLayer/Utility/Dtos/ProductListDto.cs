using System;
using Entities;

namespace Business.Dtos
{
	public class ProductListDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

    }
}

