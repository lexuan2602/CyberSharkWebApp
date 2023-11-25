using AutoMapper;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.CategoryDTO;
using TEST_CRUD.Services.Categories;

namespace TEST_CRUD.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _repo = categoryRepo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetCategoryDto>> GetById(int id)
        {
            var getCategory = await _repo.GetById(id);
            ServiceResponse<GetCategoryDto> response = new ServiceResponse<GetCategoryDto>();
            response.Data = _mapper.Map<GetCategoryDto?>(getCategory);
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;
        }
        public async Task<ServiceResponse<IEnumerable<GetCategoryDto?>>> GetList(string search, int page)
        {
            var categoryList = await _repo.GetList(search, page);
            ServiceResponse<IEnumerable<GetCategoryDto>> response = new ServiceResponse<IEnumerable<GetCategoryDto>>();
            response.Data = categoryList.Select(c => _mapper.Map<GetCategoryDto>(c)).ToList();
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;

        }
        public async Task<ServiceResponse<GetCategoryDto>> Add(AddCategoryDto category)
        {
            //if (category == null) return null;
            var mapCategory = _mapper.Map<Category>(category);
            var checkName = await _repo.GetList(mapCategory.Name, 1);
            ServiceResponse<GetCategoryDto> response = new ServiceResponse<GetCategoryDto>();

            if (checkName.Count() > 0)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Duplicate Name!!!!";
                return response;
            }
            var createdCategory = await _repo.Add(mapCategory);
            response.Data = _mapper.Map<GetCategoryDto?>(createdCategory);
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;
        }

        public async Task<ServiceResponse<GetCategoryDto>> Update(AddCategoryDto updateCategory, int id)
        {
            //var mapCategory = _mapper.Map<Category>(updateCategory);
            var updatedCategory = await _repo.Update(updateCategory, id);
            ServiceResponse<GetCategoryDto> response = new ServiceResponse<GetCategoryDto>();
            response.Data = _mapper.Map<GetCategoryDto?>(updatedCategory);
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;

        }

        public async Task<ServiceResponse<GetCategoryDto>> Delete(int id)
        {
            var deletedCategory = await _repo.Delete(id);
            ServiceResponse<GetCategoryDto> response = new ServiceResponse<GetCategoryDto>();
            response.Data = _mapper.Map<GetCategoryDto?>(deletedCategory);
            if (response.Data != null)
            {
                response.Success = true;
                response.Message = "Success";

            }
            else
            {
                response.Success = false;
                response.Message = "Failed";
            }
            return response;
        }


    }
}
