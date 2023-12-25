using AutoMapper;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.ReviewDTO;
using TEST_CRUD.Repositories;


namespace TEST_CRUD.Services.Reviews
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repo;
        private readonly IMapper _mapper;
        public ReviewService(IReviewRepository reviewRepo, IMapper mapper)
        {
            _repo = reviewRepo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetReviewDto>> GetById(int id)
        {
            var getReview = await _repo.GetById(id);
            ServiceResponse<GetReviewDto> response = new ServiceResponse<GetReviewDto>();
            response.Data = _mapper.Map<GetReviewDto?>(getReview);
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;
        }
        public async Task<ServiceResponse<IEnumerable<GetReviewDto?>>> GetList()
        {
            var reviewList = await _repo.GetList();
            ServiceResponse<IEnumerable<GetReviewDto>> response = new ServiceResponse<IEnumerable<GetReviewDto>>();
            response.Data = reviewList.Select(c => _mapper.Map<GetReviewDto>(c)).ToList();
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;

        }
        public async Task<ServiceResponse<GetReviewDto>> Add(AddReviewDto review)
        {
            //if (review == null) return null;
            var mapReview = _mapper.Map<Review>(review);
            var checkName = await _repo.GetList();
            ServiceResponse<GetReviewDto> response = new ServiceResponse<GetReviewDto>();

            if (checkName.Count() > 0)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Duplicate Name!!!!";
                return response;
            }
            var createdReview = await _repo.Add(mapReview);
            response.Data = _mapper.Map<GetReviewDto?>(createdReview);
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;
        }

        public async Task<ServiceResponse<GetReviewDto>> Update(AddReviewDto updateReview, int id)
        {
            //var mapReview = _mapper.Map<Review>(updateReview);
            var updatedReview = await _repo.Update(updateReview, id);
            ServiceResponse<GetReviewDto> response = new ServiceResponse<GetReviewDto>();
            response.Data = _mapper.Map<GetReviewDto?>(updatedReview);
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;

        }

        public async Task<ServiceResponse<GetReviewDto>> Delete(int id)
        {
            var deletedReview = await _repo.Delete(id);
            ServiceResponse<GetReviewDto> response = new ServiceResponse<GetReviewDto>();
            response.Data = _mapper.Map<GetReviewDto?>(deletedReview);
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;
        }

    }
}
