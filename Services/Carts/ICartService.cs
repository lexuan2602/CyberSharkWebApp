using TEST_CRUD.DTO;
using TEST_CRUD.DTO.CartDTO;

namespace TEST_CRUD.Services.Carts
{
    public interface ICartService
    {
        //Task<ServiceResponse<IEnumerable<GetBrandDto?>>> GetList(string search, int page);
        //Task<ServiceResponse<GetBrandDto?>> GetById(int brandid);
        public Task<ServiceResponse<GetCartDto?>> Update(AddCartDto cart);
        public Task<ServiceResponse<GetCartDto?>> Add(AddCartDto cart);
        public Task<ServiceResponse<GetCartDto?>> Delete(int customerId, int productId);
        //Task<ServiceResponse<GetBrandDto?>> Update(AddBrandDto brand, int brandid);
        //Task<ServiceResponse<GetBrandDto?>> Delete(int brandid);
    }
}
