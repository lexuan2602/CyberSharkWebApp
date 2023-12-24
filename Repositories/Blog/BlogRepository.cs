using Microsoft.EntityFrameworkCore;
using TEST_CRUD.Data;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.BlogDTO;

namespace TEST_CRUD.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CyberSharkContext appDbContext;

        public BlogRepository(CyberSharkContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Blog?>> GetList(string search)
        {
            var blogList = appDbContext.Blog.AsQueryable();
            //// Filter Items has been Deleted /////////////////////
            blogList = blogList.Where(b => b.IsDeleted != true);

            //////// Search /////////////////////////
            if (!string.IsNullOrEmpty(search))
            {
                blogList = blogList.Where(b => b.Title == search);
            }
            //var pageResult = 2f;  // The number of items in a page
            //var pageCount = Math.Ceiling(blogList.Count() / pageResult); // The number of items
            //blogList = blogList.Skip((page - 1) * (int) pageResult).Take((int)pageResult);
            return await blogList.ToListAsync();
        }
        public async Task<Blog> GetById(int id)
        {
            return await appDbContext.Blog.Where(b => b.IsDeleted == false).FirstOrDefaultAsync(br => br.Id == id);
        }
        public async Task<Blog> Add(Blog blog)
        {
            var addBlog = await appDbContext.Blog.AddAsync(blog);
            await appDbContext.SaveChangesAsync();
            return addBlog.Entity;
        }
        public async Task<Blog> Update(AddBlogDto blog, int Id)
        {
            var result = await appDbContext.Blog.FirstOrDefaultAsync(br => br.Id == Id);

            if (result != null)
            {

                result.Title = blog.Title;
                result.Content = blog.Content;
                result.Blog_Images = blog.Blog_Images;
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public async Task<Blog> Delete(int id)
        {
            var result = await appDbContext.Blog.FirstOrDefaultAsync(br => br.Id == id);
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
