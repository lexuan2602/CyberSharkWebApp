using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.CartDTO;
using TEST_CRUD.Repositories.Carts;

namespace TEST_CRUD.Services.Carts
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repo;
        private readonly IMapper _mapper;
        public CartService(ICartRepository cartRepo, IMapper mapper)
        {
            _repo = cartRepo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetCartDto?>> Update(AddCartDto cart)
        {
            //var cart =
            ServiceResponse<GetCartDto> response = new ServiceResponse<GetCartDto>();
            var updateCart = await _repo.UpdateCart(cart);
            response.Data = updateCart;
            response.Success = true;
            response.Message = "Success";
            return response;
        }
        public async Task<ServiceResponse<GetCartDto?>> Add(AddCartDto cart)
        {
            
            ServiceResponse<GetCartDto> response = new ServiceResponse<GetCartDto>();
            var addCart = await _repo.AddCart(cart);
            response.Data = addCart;
            response.Success = true;
            response.Message = "Success";
            return response;
        }
        public async Task<ServiceResponse<GetCartDto?>> Delete(int customerId, int productId)
        {
         
            ServiceResponse<GetCartDto> response = new ServiceResponse<GetCartDto>();
            var deleteCart = await _repo.DeleteItemInCart(customerId,productId);
            response.Data = deleteCart;
            response.Success = true;
            response.Message = "Success";
            return response;
        }
    }
}
