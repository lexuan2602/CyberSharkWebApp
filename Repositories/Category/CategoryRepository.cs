using Microsoft.EntityFrameworkCore;
using System;
using TEST_CRUD.Data;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.CategoryDTO;

namespace TEST_CRUD
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CyberSharkContext appDbContext;
        public CategoryRepository(CyberSharkContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Category?>> GetList(string search, int page)
        {
            var categoryList = appDbContext.Category.AsQueryable();
            //// Filter Items has been Deleted /////////////////////
            categoryList = categoryList.Where(b => b.IsDeleted != true);

            //////// Search /////////////////////////
            if (!string.IsNullOrEmpty(search))
            {
                categoryList = categoryList.Where(b => b.Name == search);
            }
            var pageResult = 2f;  // The number of items in a page
            var pageCount = Math.Ceiling(categoryList.Count() / pageResult); // The number of items
            categoryList = categoryList.Skip((page - 1) * (int)pageResult).Take((int)pageResult);
            return await categoryList.ToListAsync();
        }
        public async Task<Category> GetById(int id)
        {
            return await appDbContext.Category.Where(b => b.IsDeleted == false).FirstOrDefaultAsync(br => br.Id == id);
        }
        public async Task<Category> Add(Category category)
        {
            var addCategory = await appDbContext.Category.AddAsync(category);
            await appDbContext.SaveChangesAsync();
            return addCategory.Entity;
        }
        public async Task<Category> Update(AddCategoryDto category, int Id)
        {
            var result = await appDbContext.Category.FirstOrDefaultAsync(br => br.Id == Id);

            if (result != null)
            {

                result.Name = category.Name;
                result.Category_Image = category.Category_Image;
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public async Task<Category> Delete(int id)
        {
            var result = await appDbContext.Category.FirstOrDefaultAsync(br => br.Id == id);
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
