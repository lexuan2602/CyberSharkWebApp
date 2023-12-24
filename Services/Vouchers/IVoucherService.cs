using TEST_CRUD.DTO;
using TEST_CRUD.DTO.VoucherDTO;

namespace TEST_CRUD.Services.Vouchers
{
    public interface IVoucherService
    {
        Task<ServiceResponse<IEnumerable<GetVoucherDto?>>> GetList();
        Task<ServiceResponse<GetVoucherDto?>> GetById(int voucherid);
        Task<ServiceResponse<GetVoucherDto?>> Add(AddVoucherDto voucher);
        Task<ServiceResponse<GetVoucherDto?>> Update(AddVoucherDto voucher, int voucherid);
        Task<ServiceResponse<GetVoucherDto?>> Delete(int voucherid);
    }
}
