using TEST_CRUD.DTO;
using TEST_CRUD.DTO.ProductDTO;

namespace TEST_CRUD.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetList(string search, int page);
        public Task<Product?> GetById(int id);
        public Task<Product?> Add(Product product);
        public Task<Product?> Update(AddProductDto product, int id);
        public Task<Product?> Delete(int id);
    }
}
