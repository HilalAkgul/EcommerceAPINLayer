using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Cart;
using Business.Product;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;

        }
        [HttpGet]
        [Route("ListProduct")]
        public IActionResult ListProduct()
        {
            var list = productService.List();
            return Ok(list);
        }
        [HttpGet]
        [Route("ProductCartList")]
        public IActionResult ProductCartList(int userId)
        {
            var res = productService.CartList(userId);
            return Ok(res);
        }

    }
}