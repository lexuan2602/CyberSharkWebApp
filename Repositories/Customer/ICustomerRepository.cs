using TEST_CRUD.DTO;
using TEST_CRUD.DTO.CustomerDTO;

namespace TEST_CRUD.Repositories.Customers
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetList(string search, int page);
        public Task<Customer?> GetById(int id);
        public Task<Customer?> Add(Customer customer);
        public Task<Customer?> Update(AddCustomerDto customer, int id);
        public Task<Customer?> Delete(int id);
    }
}
