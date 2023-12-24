using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.BlogDTO;
using TEST_CRUD.Services;
using TEST_CRUD.Services.Blogs;

namespace TEST_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetBlogDto>>> GetBlogList(string search = "", int page = 1)
        {
            try
            {
                var result = await _blogService.GetList(search, page);
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
        public async Task<ActionResult<ServiceResponse<GetBlogDto>>> GetSingle(int id)
        {
            try
            {
                var result = await _blogService.GetById(id);
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
        public async Task<ActionResult<ServiceResponse<GetBlogDto>>> AddBlog(AddBlogDto blog)
        {
            try
            {
                var result = await _blogService.Add(blog);
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
        public async Task<ActionResult<ServiceResponse<GetBlogDto>>> UpdateCharacter(AddBlogDto updatedCharacter, int id)
        {
            try
            {
                var result = await _blogService.Update(updatedCharacter, id);
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
        public async Task<ActionResult<ServiceResponse<GetBlogDto>>> DeleteBlog(int blogId)
        {
            var result = await _blogService.Delete(blogId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }
    }
}
