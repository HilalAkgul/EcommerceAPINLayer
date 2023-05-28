using System;
using Business.Dtos;

namespace Business.User
{
	public interface IUserService
	{
		int  Login(string username,string password);
	}
}

