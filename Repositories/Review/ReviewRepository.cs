using Microsoft.EntityFrameworkCore;
using TEST_CRUD.Data;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.ReviewDTO;

namespace TEST_CRUD.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CyberSharkContext appDbContext;

        public ReviewRepository(CyberSharkContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Review?>> GetList()
        {
            var reviewList = appDbContext.Review.AsQueryable();
            //// Filter Items has been Deleted /////////////////////
            reviewList = reviewList.Where(b => b.IsDeleted != true);

            //////// Search /////////////////////////
            //if (!string.IsNullOrEmpty(search))
            //{
            //    reviewList = reviewList.Where(b => b.Name == search);
            //}
            //var pageResult = 2f;  // The number of items in a page
            //var pageCount = Math.Ceiling(reviewList.Count() / pageResult); // The number of items
            //reviewList = reviewList.Skip((page - 1) * (int) pageResult).Take((int)pageResult);
            return await reviewList.ToListAsync();
        }
        public async Task<Review> GetById(int id)
        {
            return await appDbContext.Review.Where(b => b.IsDeleted == false).FirstOrDefaultAsync(br => br.Id == id);
        }
        public async Task<Review> Add(Review review)
        {
            var addReview = await appDbContext.Review.AddAsync(review);
            await appDbContext.SaveChangesAsync();
            return addReview.Entity;
        }
        public async Task<Review> Update(AddReviewDto review, int Id)
        {
            var result = await appDbContext.Review.FirstOrDefaultAsync(br => br.Id == Id);

            if (result != null)
            {

                result.Rating = review.Rating;
                review.Content = result.Content;
                result.Review_Images = review.Review_Images;
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public async Task<Review> Delete(int id)
        {
            var result = await appDbContext.Review.FirstOrDefaultAsync(br => br.Id == id);
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
