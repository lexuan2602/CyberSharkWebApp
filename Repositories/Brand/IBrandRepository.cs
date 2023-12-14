using TEST_CRUD.DTO;

namespace TEST_CRUD
{
    public interface IBrandRepository
    {
        public Task<IEnumerable<Brand>> GetList(string search);
        public Task<Brand?> GetById(int id);
        public Task<Brand?> Add(Brand brand);
        public Task<Brand?> Update(AddBrandDto brand, int id);
        public Task<Brand?> Delete(int id);
    }
}
