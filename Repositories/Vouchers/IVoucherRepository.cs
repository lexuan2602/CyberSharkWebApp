using TEST_CRUD.DTO;
using TEST_CRUD.DTO.VoucherDTO;

namespace TEST_CRUD.Repositories.Vouchers
{
    public interface IVoucherRepository
    {
        public Task<IEnumerable<Voucher>> GetList();
        public Task<Voucher?> GetById(int id);
        public Task<Voucher?> Add(Voucher voucher);
        public Task<Voucher?> Update(AddVoucherDto voucher, int id);
        public Task<Voucher?> Delete(int id);
    }
}
