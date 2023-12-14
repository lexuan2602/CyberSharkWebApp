using TEST_CRUD.DTO;
using TEST_CRUD.DTO.OrderDTO;

namespace TEST_CRUD.Repositories
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<GetOrderDto>> GetList(string search);
        public Task<GetOrderDto?> GetById(int id);
        public Task<GetOrderDto?> Add(AddOrderDto order);
        public Task<GetOrderDto?> UpdateOrderStatus(int orderid, string status);
        public Task<GetOrderDto?> GetByCustomerId(int id);
    }
}
