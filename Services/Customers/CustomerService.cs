using AutoMapper;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.CustomerDTO;
using TEST_CRUD.Repositories.Customers;

namespace TEST_CRUD.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepo, IMapper mapper)
        {
            _repo = customerRepo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetCustomerDto>> GetById(int id)
        {
            var getCustomer = await _repo.GetById(id);
            ServiceResponse<GetCustomerDto> response = new ServiceResponse<GetCustomerDto>();
            response.Data = _mapper.Map<GetCustomerDto?>(getCustomer);
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;
        }
        public async Task<ServiceResponse<IEnumerable<GetCustomerDto?>>> GetList(string search, int page)
        {
            var customerList = await _repo.GetList(search, page);
            ServiceResponse<IEnumerable<GetCustomerDto>> response = new ServiceResponse<IEnumerable<GetCustomerDto>>();
            response.Data = customerList.Select(c => _mapper.Map<GetCustomerDto>(c)).ToList();
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;

        }
        public async Task<ServiceResponse<GetCustomerDto>> Add(AddCustomerDto customer)
        {
            //if (customer == null) return null;
            var mapCustomer = _mapper.Map<Customer>(customer);
            var checkName = await _repo.GetList(mapCustomer.Name, 1);
            ServiceResponse<GetCustomerDto> response = new ServiceResponse<GetCustomerDto>();

            if (checkName.Count() > 0)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Duplicate Name!!!!";
                return response;
            }
            var createdCustomer = await _repo.Add(mapCustomer);
            response.Data = _mapper.Map<GetCustomerDto?>(createdCustomer);
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;
        }

        public async Task<ServiceResponse<GetCustomerDto>> Update(AddCustomerDto updateCustomer, int id)
        {
            //var mapCustomer = _mapper.Map<Customer>(updateCustomer);
            var updatedCustomer = await _repo.Update(updateCustomer, id);
            ServiceResponse<GetCustomerDto> response = new ServiceResponse<GetCustomerDto>();
            response.Data = _mapper.Map<GetCustomerDto?>(updatedCustomer);
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;

        }

        public async Task<ServiceResponse<GetCustomerDto>> Delete(int id)
        {
            var deletedCustomer = await _repo.Delete(id);
            ServiceResponse<GetCustomerDto> response = new ServiceResponse<GetCustomerDto>();
            response.Data = _mapper.Map<GetCustomerDto?>(deletedCustomer);
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;
        }

    }
}
