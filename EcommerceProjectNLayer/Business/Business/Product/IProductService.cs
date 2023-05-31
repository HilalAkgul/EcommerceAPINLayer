using System;
using Business.Dtos;
using Utility;

namespace Business.Product
{
	public interface IProductService
	{
		Result<List<ProductListDto>>  List();
        Result<List<Entities.Product>> CartList(int userId);
    }
}

