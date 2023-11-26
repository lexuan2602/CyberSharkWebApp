using TEST_CRUD.DTO;
using TEST_CRUD.DTO.ProductDTO;

namespace TEST_CRUD.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<IEnumerable<GetProductDto?>>> GetList(string search, int page);
        Task<ServiceResponse<GetProductDto?>> GetById(int productid);

        Task<ServiceResponse<GetProductDto?>> Add(AddProductDto product);
        Task<ServiceResponse<GetProductDto?>> Update(AddProductDto product, int productid);
        Task<ServiceResponse<GetProductDto?>> Delete(int productid);
    }
}
