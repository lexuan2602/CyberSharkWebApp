
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.CategoryDTO;

namespace TEST_CRUD
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetList(string search, int page);
        public Task<Category?> GetById(int id);
        public Task<Category?> Add(Category brand);
        public Task<Category?> Update(AddCategoryDto brand, int id);
        public Task<Category?> Delete(int id);
    }
}
