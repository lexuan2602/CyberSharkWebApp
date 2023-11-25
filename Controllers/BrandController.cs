using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TEST_CRUD.DTO;
using TEST_CRUD.Models;
using TEST_CRUD.Services;

namespace TEST_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetBrandDto>>> GetBrandList(string search = "", int page = 1)
        {
            try
            {
                var result = await _brandService.GetList(search, page);
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
        public async Task<ActionResult<ServiceResponse<GetBrandDto>>> GetSingle(int id)
        {
            try
            {
                var result = await _brandService.GetById(id);
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
        public async Task<ActionResult<ServiceResponse<GetBrandDto>>> AddBrand(AddBrandDto brand)
        {
            try
            {
                var result = await _brandService.Add(brand);
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
        public async Task<ActionResult<ServiceResponse<GetBrandDto>>> UpdateCharacter(AddBrandDto updatedCharacter, int id)
        {
            try
            {
                var result = await _brandService.Update(updatedCharacter, id);
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
        public async Task<ActionResult<ServiceResponse<GetBrandDto>>> DeleteBrand(int brandId)
        {
            var result = await _brandService.Delete(brandId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }
    }
}
