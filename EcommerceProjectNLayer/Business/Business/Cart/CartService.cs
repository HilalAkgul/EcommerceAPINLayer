using System;
using AutoMapper;
using Business.Dtos;
using DAL.Base;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace Business.Cart
{
    public class CartService : ICartService
    {
        private readonly IMapper mapper;
        private readonly AppRepository<Entities.Cart> repository;
        public CartService(IMapper mapper, AppRepository<Entities.Cart> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public Result<bool> AddCart(int productId,int userId)
        {
            try
            {
                repository.Add(new Entities.Cart
                {
                    ProductId = productId,
                    UserId = userId
                });

                return new Result<bool>(true,true);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public Result<int> CartCount(int userId)
        {
            try
            {
                var list = repository.List().Where(x => x.UserId == userId).ToList();
                return new Result<int>(list.Count(),true);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public Result<double> CartTotalPrice(int userId)
        {
            try
            {
                var total = repository.Queryable().Include(x => x.Product).Select(X => X.Product).Sum(X => X.Price);

                var value = Math.Round(total, 2);
                return new Result<double>(value,true);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public Result<bool> RemoveCart(int productId, int userId)
        {
            try
            {
                var ent = repository.List().Where(x => x.UserId == userId && x.ProductId == productId).FirstOrDefault();
                if (ent != null) repository.Remove(ent.Id);
                return new Result<bool>(true,true);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}

