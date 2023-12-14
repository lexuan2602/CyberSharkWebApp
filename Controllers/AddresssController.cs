using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.AddressDTO;
using TEST_CRUD.Services;
using TEST_CRUD.Services.Addresses;

namespace TEST_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddresssController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddresssController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetAddressDto>>> GetAddressList(string search = "", int page = 1)
        {
            try
            {
                var result = await _addressService.GetList(page);
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
        public async Task<ActionResult<ServiceResponse<GetAddressDto>>> GetSingle(int id)
        {
            try
            {
                var result = await _addressService.GetById(id);
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
        public async Task<ActionResult<ServiceResponse<GetAddressDto>>> AddAddress(AddAddressDto Address)
        {
            try
            {
                var result = await _addressService.Add(Address);
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
        public async Task<ActionResult<ServiceResponse<GetAddressDto>>> UpdateCharacter(AddAddressDto updatedCharacter, int id)
        {
            try
            {
                var result = await _addressService.Update(updatedCharacter, id);
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
        public async Task<ActionResult<ServiceResponse<GetAddressDto>>> DeleteAddress(int AddressId)
        {
            var result = await _addressService.Delete(AddressId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }
    }
}
