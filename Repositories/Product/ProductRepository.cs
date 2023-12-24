using Microsoft.EntityFrameworkCore;
using TEST_CRUD.Data;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.ProductDTO;

namespace TEST_CRUD.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CyberSharkContext appDbContext;

        public ProductRepository(CyberSharkContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Product?>> GetList(string search, int page)
        {
            var productList = appDbContext.Product.AsQueryable();
            //// Filter Items has been Deleted /////////////////////
            productList = productList.Where(b => b.IsDeleted != true);

            //////// Search /////////////////////////
            if (!string.IsNullOrEmpty(search))
            {
                productList = productList.Where(b => b.Name == search);
            }
            var pageResult = 2f;  // The number of items in a page
            var pageCount = Math.Ceiling(productList.Count() / pageResult); // The number of items
            productList = productList.Skip((page - 1) * (int)pageResult).Take((int)pageResult);
            return await productList.ToListAsync();
        }

        public async Task<IEnumerable<Product?>> SortFromHighToLow(string direction)
        {
            var productList = appDbContext.Product.AsQueryable();
            //// Filter Items has been Deleted /////////////////////
            productList = productList.Where(b => b.IsDeleted != true);

            //////// Sort /////////////////////////
            if(direction == "asc")
            {
                productList = productList.OrderBy(b => b.Sale_Price);

            }
            else
            {
                productList = productList.OrderByDescending(b => b.Sale_Price);
            }


            return await productList.ToListAsync();
        }
        public async Task<IEnumerable<Product?>> GetInRange(double top, double down)
        {
            var productList = appDbContext.Product.AsQueryable();
            //// Filter Items has been Deleted /////////////////////
            productList = productList.Where(b => b.IsDeleted != true);

            //////// Sort /////////////////////////
            
            productList = productList.Where(b => (b.Sale_Price >= down && b.Sale_Price <= top));

            return await productList.ToListAsync();
        }

        public async Task<IEnumerable<Product?>> GetByCategory(int categoryId)
        {
            var productList = appDbContext.Product.AsQueryable();
            //// Filter Items has been Deleted /////////////////////
            productList = productList.Where(b => b.IsDeleted != true);

            //////// GetByCategory /////////////////////////

            productList = productList.Where(b => b.Category_Id == categoryId);

            return await productList.ToListAsync();
        }
        public async Task<Product> GetById(int id)
        {
            return await appDbContext.Product.Where(b => b.IsDeleted == false).FirstOrDefaultAsync(br => br.Id == id);
        }
        public async Task<Product> Add(Product product)
        {
            var addProduct = await appDbContext.Product.AddAsync(product);
            await appDbContext.SaveChangesAsync();
            return addProduct.Entity;
        }
        public async Task<Product> Update(AddProductDto product, int Id)
        {
            var result = await appDbContext.Product.FirstOrDefaultAsync(br => br.Id == Id);

            if (result != null)
            {

                result.Name = product.Name;
                result.Cost_Price = product.Cost_Price;
                result.Sale_Price = product.Sale_Price;
                result.Description = product.Description;
                result.Quantity = product.Quantity;
                result.Product_Images = product.Product_Images;
                result.Category_Id = product.Category_Id;
                result.Brand_Id = product.Brand_Id;
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public async Task<Product> Delete(int id)
        {
            var result = await appDbContext.Product.FirstOrDefaultAsync(br => br.Id == id);
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
