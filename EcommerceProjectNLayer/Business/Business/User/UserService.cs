using System;
using AutoMapper;
using Business.Dtos;
using DAL.Base;
using DAL.Repositories;

namespace Business.User
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly AppRepository<Entities.User> repository;
        public UserService(IMapper mapper, AppRepository<Entities.User> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public int Login(string username,string password)
        {
            var user = repository.List().Where(x => x.UserName == username && x.Password == password).FirstOrDefault();

            return user == null ? 0:user.Id ;
        }
    }
}

