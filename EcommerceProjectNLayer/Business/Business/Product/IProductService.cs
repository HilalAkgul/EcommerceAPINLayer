using System;
using Business.Dtos;

namespace Business.Product
{
	public interface IProductService
	{
		List<ProductListDto>  List();
        List<Entities.Product> CartList(int userId);
    }
}

