using TEST_CRUD.DTO;
using TEST_CRUD.DTO.ReviewDTO;

namespace TEST_CRUD.Services.Reviews
{
    public interface IReviewService
    {
        Task<ServiceResponse<IEnumerable<GetReviewDto?>>> GetList();
        Task<ServiceResponse<GetReviewDto?>> GetById(int reviewid);
        Task<ServiceResponse<GetReviewDto?>> Add(AddReviewDto review);
        Task<ServiceResponse<GetReviewDto?>> Update(AddReviewDto review, int reviewid);
        Task<ServiceResponse<GetReviewDto?>> Delete(int reviewid);
    }
}
