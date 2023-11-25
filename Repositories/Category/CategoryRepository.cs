using Microsoft.EntityFrameworkCore;
using System;
using TEST_CRUD.Data;
using TEST_CRUD.DTO;
namespace TEST_CRUD.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CyberSharkContext appDbContext;
        public CategoryRepository(CyberSharkContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Brand?>> GetList(string search, int page)
        {
            var brandList = appDbContext.Brand.AsQueryable();
            //// Filter Items has been Deleted /////////////////////
            brandList = brandList.Where(b => b.IsDeleted != true);

            //////// Search /////////////////////////
            if (!string.IsNullOrEmpty(search))
            {
                brandList = brandList.Where(b => b.Name == search);
            }
            var pageResult = 2f;  // The number of items in a page
            var pageCount = Math.Ceiling(brandList.Count() / pageResult); // The number of items
            brandList = brandList.Skip((page - 1) * (int)pageResult).Take((int)pageResult);
            return await brandList.ToListAsync();
        }
        public async Task<Brand> GetById(int id)
        {
            return await appDbContext.Brand.FirstOrDefaultAsync(br => br.Id == id);
        }
        public async Task<Brand> Add(Brand brand)
        {
            var addBrand = await appDbContext.Brand.AddAsync(brand);
            await appDbContext.SaveChangesAsync();
            return addBrand.Entity;
        }
        public async Task<Brand> Update(AddBrandDto brand, int Id)
        {
            var result = await appDbContext.Brand.FirstOrDefaultAsync(br => br.Id == Id);

            if (result != null)
            {
                //result.Id = brand.Id;
                result.Name = brand.Name;
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public async Task<Brand> Delete(int id)
        {
            var result = await appDbContext.Brand.FirstOrDefaultAsync(br => br.Id == id);
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
