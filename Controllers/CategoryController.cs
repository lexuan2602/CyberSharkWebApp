using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEST_CRUD.DTO;
using TEST_CRUD.Services;
using TEST_CRUD.Services.Category;

namespace TEST_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategoryList(string search = "", int page = 1)
        {
            try
            {
                var result = await _categoryService.GetList(search, page);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingle(int id)
        {
            try
            {
                var result = await _categoryService.GetById(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddBrand(AddBrandDto brand)
        {
            try
            {
                var result = await _categoryService.Add(brand);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCharacter(AddBrandDto updatedCharacter, int id)
        {
            try
            {
                var result = await _categoryService.Update(updatedCharacter, id);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
        [HttpDelete]
        public async Task<ActionResult> DeleteBrand(int brandId)
        {
            var result = await _categoryService.Delete(brandId);
            if (result != null)
            {
                return Ok("Record has been deleted");
            }
            return BadRequest();


        }
    }
}
