using System;
using AutoMapper;
using Business.Dtos;
using DAL.Base;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Utility;

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

        public Result<List<Entities.Product>> CartList(int userId)
        {
            try
            {
                var list = repository.Queryable().Include(x => x.Carts).Where(x => x.Carts.Count > 0)
                                .ToList();
                return new Result<List<Entities.Product>>(list,true);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        public Result<List<ProductListDto>> List()
        {
            try
            {
                var productList = repository.List();
                var list = mapper.Map<List<ProductListDto>>(productList);
                return new Result<List<ProductListDto>>(list, true);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}

