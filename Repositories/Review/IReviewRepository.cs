using TEST_CRUD.DTO;
using TEST_CRUD.DTO.ReviewDTO;

namespace TEST_CRUD.Repositories
{
    public interface IReviewRepository
    {
        public Task<IEnumerable<Review>> GetList();
        public Task<Review?> GetById(int id);
        public Task<Review?> Add(Review review);
        public Task<Review?> Update(AddReviewDto review, int id);
        public Task<Review?> Delete(int id);
    }
}
