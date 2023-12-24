using Microsoft.EntityFrameworkCore;
using TEST_CRUD.Data;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.VoucherDTO;

namespace TEST_CRUD.Repositories.Vouchers
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly CyberSharkContext appDbContext;

        public VoucherRepository(CyberSharkContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Voucher?>> GetList()
        {
            var voucherList = appDbContext.Voucher.AsQueryable();
            //// Filter Items has been Deleted /////////////////////
            voucherList = voucherList.Where(b => b.IsDeleted != true);

            //////// Search /////////////////////////
            //if (!string.IsNullOrEmpty(search))
            //{
            //    voucherList = voucherList.Where(b => b.Name == search);
            //}
            //var pageResult = 2f;  // The number of items in a page
            //var pageCount = Math.Ceiling(voucherList.Count() / pageResult); // The number of items
            //voucherList = voucherList.Skip((page - 1) * (int) pageResult).Take((int)pageResult);
            return await voucherList.ToListAsync();
        }
        public async Task<Voucher> GetById(int id)
        {
            return await appDbContext.Voucher.Where(b => b.IsDeleted == false).FirstOrDefaultAsync(br => br.Id == id);
        }
        public async Task<Voucher> Add(Voucher voucher)
        {
            var addVoucher = await appDbContext.Voucher.AddAsync(voucher);
            await appDbContext.SaveChangesAsync();
            return addVoucher.Entity;
        }
        public async Task<Voucher> Update(AddVoucherDto voucher, int Id)
        {
            var result = await appDbContext.Voucher.FirstOrDefaultAsync(br => br.Id == Id);

            if (result != null)
            {

                result.Name = voucher.Name;
                result.Percent = voucher.Percent;
                result.Date_Start = voucher.Date_Start;
                result.Date_Expired = voucher.Date_Expired;
                result.Used_Number = voucher.Used_Number;
                result.Max_Used_Number = voucher.Max_Used_Number;   
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public async Task<Voucher> Delete(int id)
        {
            var result = await appDbContext.Voucher.FirstOrDefaultAsync(br => br.Id == id);
            if (result != null)
            {
                result.IsDeleted = true;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
