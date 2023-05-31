using System;
using Business.Dtos;
using Utility;

namespace Business.Cart
{
	public interface ICartService
	{
		Result<bool>  AddCart(int productId,int userId);
        Result<bool> RemoveCart(int productId, int userId);
        Result<int> CartCount(int userId);
        Result<double> CartTotalPrice(int userId);
      
    }
}

