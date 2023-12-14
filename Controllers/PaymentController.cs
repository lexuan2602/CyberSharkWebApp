using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.PaymentDTO;
using TEST_CRUD.Services;
using TEST_CRUD.Services.Payments;

namespace TEST_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

       
 
        [HttpGet("{orderId}")]
        public async Task<ActionResult<ServiceResponse<GetPaymentDto>>> GetByOrderNumber(string orderNumbber)
        {
            try
            {
                var result = await _paymentService.GetByOrderId(orderNumbber);
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
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetPaymentDto>>> AddPayment(AddPaymentDto payment)
        {
            try
            {
                var result = await _paymentService.Add(payment);
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
        
        
    }
}
