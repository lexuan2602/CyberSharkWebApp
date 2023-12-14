using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.CustomerDTO;
using TEST_CRUD.Services;
using TEST_CRUD.Services.Customers;

namespace TEST_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetCustomerDto>>> GetCustomerList(string search = "", int page = 1)
        {
            try
            {
                var result = await _customerService.GetList(search, page);
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
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCustomerDto>>> GetSingle(int id)
        {
            try
            {
                var result = await _customerService.GetById(id);
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
        public async Task<ActionResult<ServiceResponse<GetCustomerDto>>> AddCustomer(AddCustomerDto customer)
        {
            try
            {
                var result = await _customerService.Add(customer);
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
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCustomerDto>>> UpdateCharacter(AddCustomerDto updatedCharacter, int id)
        {
            try
            {
                var result = await _customerService.Update(updatedCharacter, id);
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
        public async Task<ActionResult<ServiceResponse<GetCustomerDto>>> DeleteCustomer(int customerId)
        {
            var result = await _customerService.Delete(customerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }
    }
}
