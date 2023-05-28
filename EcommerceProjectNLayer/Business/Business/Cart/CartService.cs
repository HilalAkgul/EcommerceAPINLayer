using System;
using AutoMapper;
using Business.Dtos;
using DAL.Base;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

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
        public bool AddCart(int productId,int userId)
        {
             repository.Add(new Entities.Cart
            {
                ProductId=productId,
                UserId=userId
            });
           
            return true;
        }
        public int CartCount(int userId)
        {
            var list = repository.List().Where(x => x.UserId == userId).ToList();
            return list.Count();
        }

        public double CartTotalPrice(int userId)
        {
            var total = repository.Queryable().Include(x => x.Product).Select(X => X.Product).Sum(X => X.Price);

          var  value = Math.Round(total, 2);
            return value;
        }

        public bool RemoveCart(int productId, int userId)
        {
            var ent = repository.List().Where(x => x.UserId == userId&&x.ProductId==productId).FirstOrDefault();
            if(ent!=null)repository.Remove(ent.Id);
            return true;
        }
    }
}

