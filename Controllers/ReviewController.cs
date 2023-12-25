using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.ReviewDTO;
using TEST_CRUD.Services;
using TEST_CRUD.Services.Reviews;

namespace TEST_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetReviewDto>>> GetReviewList()
        {
            try
            {
                var result = await _reviewService.GetList();
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
        public async Task<ActionResult<ServiceResponse<GetReviewDto>>> GetSingle(int id)
        {
            try
            {
                var result = await _reviewService.GetById(id);
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
        public async Task<ActionResult<ServiceResponse<GetReviewDto>>> AddReview(AddReviewDto review)
        {
            try
            {
                var result = await _reviewService.Add(review);
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
        public async Task<ActionResult<ServiceResponse<GetReviewDto>>> UpdateCharacter(AddReviewDto updatedReview, int id)
        {
            try
            {
                var result = await _reviewService.Update(updatedReview, id);
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
        public async Task<ActionResult<ServiceResponse<GetReviewDto>>> DeleteReview(int reviewId)
        {
            var result = await _reviewService.Delete(reviewId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }
    }
}
