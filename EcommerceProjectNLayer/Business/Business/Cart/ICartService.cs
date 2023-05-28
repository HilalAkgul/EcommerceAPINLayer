using System;
using Business.Dtos;

namespace Business.Cart
{
	public interface ICartService
	{
		bool  AddCart(int productId,int userId);
        bool RemoveCart(int productId, int userId);
        int CartCount(int userId);
        double CartTotalPrice(int userId);
      
    }
}

