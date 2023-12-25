using AutoMapper;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.VoucherDTO;
using TEST_CRUD.Repositories.Vouchers;

namespace TEST_CRUD.Services.Vouchers
{
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepository _repo;
        private readonly IMapper _mapper;
        public VoucherService(IVoucherRepository voucherRepo, IMapper mapper)
        {
            _repo = voucherRepo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetVoucherDto>> GetById(int id)
        {
            var getVoucher = await _repo.GetById(id);
            ServiceResponse<GetVoucherDto> response = new ServiceResponse<GetVoucherDto>();
            response.Data = _mapper.Map<GetVoucherDto?>(getVoucher);
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
        public async Task<ServiceResponse<IEnumerable<GetVoucherDto?>>> GetList()
        {
            var voucherList = await _repo.GetList();
            ServiceResponse<IEnumerable<GetVoucherDto>> response = new ServiceResponse<IEnumerable<GetVoucherDto>>();
            response.Data = voucherList.Select(c => _mapper.Map<GetVoucherDto>(c)).ToList();
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
        public async Task<ServiceResponse<GetVoucherDto>> Add(AddVoucherDto voucher)
        {
            //if (voucher == null) return null;
            var mapVoucher = _mapper.Map<Voucher>(voucher);
            //var checkName = await _repo.GetList();
            ServiceResponse<GetVoucherDto> response = new ServiceResponse<GetVoucherDto>();

            //if (checkName.Count() > 0)
            //{
            //    response.Data = null;
            //    response.Success = false;
            //    response.Message = "Duplicate Name!!!!";
            //    return response;
            //}
            var createdVoucher = await _repo.Add(mapVoucher);
            response.Data = _mapper.Map<GetVoucherDto?>(createdVoucher);
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

        public async Task<ServiceResponse<GetVoucherDto>> Update(AddVoucherDto updateVoucher, int id)
        {
            //var mapVoucher = _mapper.Map<Voucher>(updateVoucher);
            var updatedVoucher = await _repo.Update(updateVoucher, id);
            ServiceResponse<GetVoucherDto> response = new ServiceResponse<GetVoucherDto>();
            response.Data = _mapper.Map<GetVoucherDto?>(updatedVoucher);
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

        public async Task<ServiceResponse<GetVoucherDto>> Delete(int id)
        {
            var deletedVoucher = await _repo.Delete(id);
            ServiceResponse<GetVoucherDto> response = new ServiceResponse<GetVoucherDto>();
            response.Data = _mapper.Map<GetVoucherDto?>(deletedVoucher);
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
