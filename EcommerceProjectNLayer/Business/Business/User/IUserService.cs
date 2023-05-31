using System;
using Business.Dtos;
using Utility;

namespace Business.User
{
	public interface IUserService
	{
		Result<int>  Login(string username,string password);
	}
}

