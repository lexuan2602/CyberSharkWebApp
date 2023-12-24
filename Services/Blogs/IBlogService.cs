using TEST_CRUD.DTO;
using TEST_CRUD.DTO.BlogDTO;

namespace TEST_CRUD.Services.Blogs
{
    public interface IBlogService
    {
        Task<ServiceResponse<IEnumerable<GetBlogDto?>>> GetList(string search, int page);
        Task<ServiceResponse<GetBlogDto?>> GetById(int blogid);
        Task<ServiceResponse<GetBlogDto?>> Add(AddBlogDto blog);
        Task<ServiceResponse<GetBlogDto?>> Update(AddBlogDto blog, int blogid);
        Task<ServiceResponse<GetBlogDto?>> Delete(int blogid);
    }
}
