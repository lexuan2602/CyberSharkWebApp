using TEST_CRUD.DTO;
using TEST_CRUD.DTO.CustomerDTO;

namespace TEST_CRUD.Services.Customers
{
    public interface ICustomerService
    {
        Task<ServiceResponse<IEnumerable<GetCustomerDto?>>> GetList(string search, int page);
        Task<ServiceResponse<GetCustomerDto?>> GetById(int customerid);

        Task<ServiceResponse<GetCustomerDto?>> Add(AddCustomerDto customer);
        Task<ServiceResponse<GetCustomerDto?>> Update(AddCustomerDto customer, int customerid);
        Task<ServiceResponse<GetCustomerDto?>> Delete(int customerid);
    }
}
