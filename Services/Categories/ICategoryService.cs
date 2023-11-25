using TEST_CRUD.DTO;
using TEST_CRUD.DTO.CategoryDTO;

namespace TEST_CRUD.Services.Categories
{
    public interface ICategoryService
    {
        Task<ServiceResponse<IEnumerable<GetCategoryDto?>>> GetList(string search, int page);
        Task<ServiceResponse<GetCategoryDto?>> GetById(int categoryid);

        Task<ServiceResponse<GetCategoryDto?>> Add(AddCategoryDto category);
        Task<ServiceResponse<GetCategoryDto?>> Update(AddCategoryDto category, int categoryid);
        Task<ServiceResponse<GetCategoryDto?>> Delete(int categoryid);
    }
}
