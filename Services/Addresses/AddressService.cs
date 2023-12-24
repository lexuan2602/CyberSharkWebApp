using AutoMapper;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.AddressDTO;
using TEST_CRUD.Repositories;

namespace TEST_CRUD.Services.Addresses
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repo;
        private readonly IMapper _mapper;
        public AddressService(IAddressRepository addressRepo, IMapper mapper)
        {
            _repo = addressRepo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetAddressDto>> GetById(int id)
        {
            var getAddress = await _repo.GetById(id);
            ServiceResponse<GetAddressDto> response = new ServiceResponse<GetAddressDto>();
            response.Data = _mapper.Map<GetAddressDto?>(getAddress);
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
        public async Task<ServiceResponse<IEnumerable<GetAddressDto?>>> GetList()
        {
            var addressList = await _repo.GetList();
            ServiceResponse<IEnumerable<GetAddressDto>> response = new ServiceResponse<IEnumerable<GetAddressDto>>();
            response.Data = addressList.Select(c => _mapper.Map<GetAddressDto>(c)).ToList();
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
        public async Task<ServiceResponse<GetAddressDto>> Add(AddAddressDto address)
        {
            //if (address == null) return null;
            var mapAddress = _mapper.Map<Address>(address);
            //var checkName = await _repo.GetList(mapAddress.Name, 1);
            ServiceResponse<GetAddressDto> response = new ServiceResponse<GetAddressDto>();
            var createdAddress = await _repo.Add(mapAddress);
            response.Data = _mapper.Map<GetAddressDto?>(createdAddress);
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

        public async Task<ServiceResponse<GetAddressDto>> Update(AddAddressDto updateAddress, int id)
        {
            //var mapAddress = _mapper.Map<Address>(updateAddress);
            var updatedAddress = await _repo.Update(updateAddress, id);
            ServiceResponse<GetAddressDto> response = new ServiceResponse<GetAddressDto>();
            response.Data = _mapper.Map<GetAddressDto?>(updatedAddress);
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

        public async Task<ServiceResponse<GetAddressDto>> Delete(int id)
        {
            var deletedAddress = await _repo.Delete(id);
            ServiceResponse<GetAddressDto> response = new ServiceResponse<GetAddressDto>();
            response.Data = _mapper.Map<GetAddressDto?>(deletedAddress);
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
