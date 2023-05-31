using System;
using AutoMapper;
using Business.Dtos;
using DAL.Base;
using DAL.Repositories;
using Utility;

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
        public  Result<int> Login(string username,string password)
        {
            try
            {
                var user = repository.List().Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
                return user != null?new Result<int>(user.Id, true): new Result<int>(false,"Kullanıcı adı veya şifre yanlış");

            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
    }
}

