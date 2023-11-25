using AutoMapper;
using TEST_CRUD.DTO;

namespace TEST_CRUD.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        
        public CategoryService(ICategoryRepository brandRepo, IMapper mapper)
        {
            _repo = brandRepo;
            _mapper = mapper;
        }
        public async Task<GetBrandDto?> GetById(int id)
        {
            var getBrand = await _repo.GetById(id);
            return _mapper.Map<GetBrandDto?>(getBrand);
        }
        public async Task<IEnumerable<GetBrandDto?>> GetList(string search, int page)
        {
            var brandList = await _repo.GetList(search, page);
            return brandList.Select(c => _mapper.Map<GetBrandDto>(c)).ToList();

        }
        public async Task<GetBrandDto?> Add(AddBrandDto brand)
        {
            //if (brand == null) return null;
            var mapBrand = _mapper.Map<Brand>(brand);
            var createdBrand = await _repo.Add(mapBrand);
            return _mapper.Map<GetBrandDto?>(createdBrand);
        }

        public async Task<GetBrandDto> Update(AddBrandDto updateBrand, int id)
        {
            var updatedBrand = await _repo.Update(updateBrand, id);
            return _mapper.Map<GetBrandDto>(updatedBrand);
        }

        public async Task<GetBrandDto> Delete(int id)
        {
            var deletedBrand = await _repo.Delete(id);
            return _mapper.Map<GetBrandDto>(deletedBrand);
        }


    }
}
