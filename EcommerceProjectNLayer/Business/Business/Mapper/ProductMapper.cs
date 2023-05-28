using System;
using AutoMapper;



namespace Business.Mapper
{
	public class ProductMapper:Profile
	{
        public ProductMapper()
        {
            CreateMap<Entities.Product, Dtos.ProductListDto>();
           
        }
    }
}

