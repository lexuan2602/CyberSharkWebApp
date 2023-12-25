using TEST_CRUD.DTO;
using TEST_CRUD.DTO.AddressDTO;

namespace TEST_CRUD.Services.Addresses
{
    public interface IAddressService
    {
        Task<ServiceResponse<IEnumerable<GetAddressDto?>>> GetList();
        Task<ServiceResponse<GetAddressDto?>> GetById(int addressid);

        Task<ServiceResponse<GetAddressDto?>> Add(AddAddressDto address);
        Task<ServiceResponse<GetAddressDto?>> Update(AddAddressDto address, int addressid);
        Task<ServiceResponse<GetAddressDto?>> Delete(int addressid);
    }
}
