using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.VoucherDTO;
using TEST_CRUD.Services;
using TEST_CRUD.Services.Vouchers;

namespace TEST_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _voucherService;
        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetVoucherDto>>> GetVoucherList()
        {
            try
            {
                var result = await _voucherService.GetList();
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
        public async Task<ActionResult<ServiceResponse<GetVoucherDto>>> GetSingle(int id)
        {
            try
            {
                var result = await _voucherService.GetById(id);
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
        public async Task<ActionResult<ServiceResponse<GetVoucherDto>>> AddVoucher(AddVoucherDto voucher)
        {
            try
            {
                var result = await _voucherService.Add(voucher);
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
        public async Task<ActionResult<ServiceResponse<GetVoucherDto>>> UpdateCharacter(AddVoucherDto updatedCharacter, int id)
        {
            try
            {
                var result = await _voucherService.Update(updatedCharacter, id);
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
        public async Task<ActionResult<ServiceResponse<GetVoucherDto>>> DeleteVoucher(int voucherId)
        {
            var result = await _voucherService.Delete(voucherId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }
    }
}
