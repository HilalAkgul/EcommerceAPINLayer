
using Business.Cart;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;

        }
        [HttpPost]
        [Route("AddCart")]
        public IActionResult AddCart(int productId, int userId)
        {
            var res = cartService.AddCart(productId, userId);
            return Ok(res);
        }

        [HttpPost]
        [Route("RemoveCart")]
        public IActionResult RemoveCart(int productId, int userId)
        {
            var res = cartService.RemoveCart(productId, userId);
            return Ok(res);
        }
        [HttpGet]
        [Route("CartCount")]
        public IActionResult CartCount(int userId)
        {
            var res = cartService.CartCount(userId);
            return Ok(res);
        }
        [HttpGet]
        [Route("CartTotalPrice")]
        public IActionResult CartTotalPrice(int userId)
        {
            var res = cartService.CartTotalPrice(userId);
            return Ok(res);
        }
    }
}