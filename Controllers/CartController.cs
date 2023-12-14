using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.CartDTO;
using TEST_CRUD.Services;
using TEST_CRUD.Services.Carts;

namespace TEST_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        //[HttpGet]
        //public async Task<ActionResult<ServiceResponse<GetCartDto>>> GetCartList(int cart_id = 0, string search = "", int page = 1)
        //{
        //    try
        //    {
        //        var result = await _cartService.GetList(cart_id, search, page);
        //        if (result.Success)
        //        {
        //            return Ok(result);
        //        }

        //        return BadRequest(result.Message);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error retrieving data from the database");
        //    }
        //}
        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCartDto>>> AddToCart(AddCartDto cart)
        {
            try
            {
                var result = await _cartService.Add(cart);
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result.Message);

            }
            catch (Exception)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError,
                //    "Error retrieving data from the database");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCartDto>>> UpdateCart(AddCartDto cart)
        {
            try
            {
                var result = await _cartService.Update(cart);
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result.Message);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetBrandDto>>> DeleteItemInCart(int customerId, int productId)
        {
            var result = await _cartService.Delete(customerId, productId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }
    }
}
