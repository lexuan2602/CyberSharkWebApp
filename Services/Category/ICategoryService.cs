using TEST_CRUD.DTO;

namespace TEST_CRUD.Services.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetBrandDto?>> GetList(string search, int page);
        Task<GetBrandDto?> GetById(int brandid);

        Task<GetBrandDto?> Add(AddBrandDto brand);
        Task<GetBrandDto?> Update(AddBrandDto brand, int brandid);
        Task<GetBrandDto?> Delete(int brandid);
    }
}
