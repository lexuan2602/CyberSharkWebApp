using Microsoft.EntityFrameworkCore;
using TEST_CRUD.Data;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.CustomerDTO;

namespace TEST_CRUD.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CyberSharkContext appDbContext;

        public CustomerRepository(CyberSharkContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Customer?>> GetList(string search, int page)
        {
            var customerList = appDbContext.Customer.AsQueryable();
            //// Filter Items has been Deleted /////////////////////
            customerList = customerList.Where(b => b.IsDeleted != true);

            //////// Search /////////////////////////
            if (!string.IsNullOrEmpty(search))
            {
                customerList = customerList.Where(b => b.Name == search);
            }
            var pageResult = 15f;  // The number of items in a page
            var pageCount = Math.Ceiling(customerList.Count() / pageResult); // The number of items
            customerList = customerList.Skip((page - 1) * (int)pageResult).Take((int)pageResult);
            return await customerList.ToListAsync();
        }
        public async Task<Customer> GetById(int id)
        {
            return await appDbContext.Customer.Where(b => b.IsDeleted == false).FirstOrDefaultAsync(cs => cs.Id == id);
        }
        public async Task<Customer> Add(Customer customer)
        {
            var addCustomer = await appDbContext.Customer.AddAsync(customer);
            await appDbContext.SaveChangesAsync();
            return addCustomer.Entity;
        }
        public async Task<Customer> Update(AddCustomerDto customer, int Id)
        {
            var result = await appDbContext.Customer.FirstOrDefaultAsync(br => br.Id == Id);

            if (result != null)
            {

                result.Name = customer.Name;
                result.Sex = customer.Sex;
                result.Date_Of_Birth = customer.Date_Of_Birth;
                result.Accumulate_Point = customer.Accumulate_Point;
                result.Telephone = customer.Telephone;
                result.Customer_Images = customer.Customer_Images;
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public async Task<Customer> Delete(int id)
        {
            var result = await appDbContext.Customer.FirstOrDefaultAsync(c => c.Id == id);
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
