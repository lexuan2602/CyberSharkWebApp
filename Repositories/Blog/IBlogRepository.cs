using TEST_CRUD.DTO;
using TEST_CRUD.DTO.BlogDTO;

namespace TEST_CRUD.Repositories
{
    public interface IBlogRepository
    {
        public Task<IEnumerable<Blog>> GetList(string search);
        public Task<Blog?> GetById(int id);
        public Task<Blog?> Add(Blog blog);
        public Task<Blog?> Update(AddBlogDto blog, int id);
        public Task<Blog?> Delete(int id);
    }
}
