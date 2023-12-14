using TEST_CRUD.DTO.CartDTO;

namespace TEST_CRUD.Repositories.Carts
{
    public interface ICartRepository
    {
        //public Task<IEnumerable<CartDetail>> GetList(string search, int page);
        //public Task<Brand?> GetById(int id);
        public Task<GetCartDto?> AddCart(AddCartDto cart);
        public Task<GetCartDto?> UpdateCart(AddCartDto cart);
        public Task<GetCartDto?> DeleteItemInCart(int customerId, int productId);
        public Task<GetCartDto?> GetCart(int customerId);
        //public Task<Brand?> Update(AddBrandDto brand, int id);
        //public Task<Brand?> Delete(int id);
    }
}
