using System;
using AutoMapper;
using Business.Dtos;
using DAL.Base;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business.Product
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly AppRepository<Entities.Product> repository;
        public ProductService(IMapper mapper, AppRepository<Entities.Product> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public List<Entities.Product> CartList(int userId)
        {
            var list = repository.Queryable().Include(x=>x.Carts).Where(x => x.Carts.Count>0)
                .ToList();
            return list;
        }
        public List<ProductListDto> List()
        {
            var productList = repository.List();
            var list = mapper.Map<List<ProductListDto>>(productList);
            return list;
        }
    }
}

