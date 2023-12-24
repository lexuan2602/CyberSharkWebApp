using AutoMapper;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.BlogDTO;
using TEST_CRUD.Repositories;

namespace TEST_CRUD.Services.Blogs
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repo;
        private readonly IMapper _mapper;
        public BlogService(IBlogRepository blogRepo, IMapper mapper)
        {
            _repo = blogRepo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetBlogDto>> GetById(int id)
        {
            var getBlog = await _repo.GetById(id);
            ServiceResponse<GetBlogDto> response = new ServiceResponse<GetBlogDto>();
            response.Data = _mapper.Map<GetBlogDto?>(getBlog);
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
        public async Task<ServiceResponse<IEnumerable<GetBlogDto?>>> GetList(string search, int page)
        {
            var blogList = await _repo.GetList(search);
            ServiceResponse<IEnumerable<GetBlogDto>> response = new ServiceResponse<IEnumerable<GetBlogDto>>();
            response.Data = blogList.Select(c => _mapper.Map<GetBlogDto>(c)).ToList();
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
        public async Task<ServiceResponse<GetBlogDto>> Add(AddBlogDto blog)
        {
            //if (blog == null) return null;
            var mapBlog = _mapper.Map<Blog>(blog);
            var checkName = await _repo.GetList(mapBlog.Title);
            ServiceResponse<GetBlogDto> response = new ServiceResponse<GetBlogDto>();

            if (checkName.Count() > 0)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Duplicate Name!!!!";
                return response;
            }
            var createdBlog = await _repo.Add(mapBlog);
            response.Data = _mapper.Map<GetBlogDto?>(createdBlog);
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

        public async Task<ServiceResponse<GetBlogDto>> Update(AddBlogDto updateBlog, int id)
        {
            //var mapBlog = _mapper.Map<Blog>(updateBlog);
            var updatedBlog = await _repo.Update(updateBlog, id);
            ServiceResponse<GetBlogDto> response = new ServiceResponse<GetBlogDto>();
            response.Data = _mapper.Map<GetBlogDto?>(updatedBlog);
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

        public async Task<ServiceResponse<GetBlogDto>> Delete(int id)
        {
            var deletedBlog = await _repo.Delete(id);
            ServiceResponse<GetBlogDto> response = new ServiceResponse<GetBlogDto>();
            response.Data = _mapper.Map<GetBlogDto?>(deletedBlog);
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
