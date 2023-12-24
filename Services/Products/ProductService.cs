using AutoMapper;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.ProductDTO;
using TEST_CRUD.Repositories;
using TEST_CRUD.Services;

namespace TEST_CRUD.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepo, IMapper mapper)
        {
            _repo = productRepo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetProductDto>> GetById(int id)
        {
            var getProduct = await _repo.GetById(id);
            ServiceResponse<GetProductDto> response = new ServiceResponse<GetProductDto>();
            response.Data = _mapper.Map<GetProductDto?>(getProduct);
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
        public async Task<ServiceResponse<IEnumerable<GetProductDto?>>> GetList(string search, int page)
        {
            var productList = await _repo.GetList(search, page);
            ServiceResponse<IEnumerable<GetProductDto>> response = new ServiceResponse<IEnumerable<GetProductDto>>();
            response.Data = productList.Select(c => _mapper.Map<GetProductDto>(c)).ToList();
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
        public async Task<ServiceResponse<IEnumerable<GetProductDto?>>> SortFromHighToLow(string direction)
        {
            var productList = await _repo.SortFromHighToLow(direction);
            ServiceResponse<IEnumerable<GetProductDto>> response = new ServiceResponse<IEnumerable<GetProductDto>>();
            response.Data = productList.Select(c => _mapper.Map<GetProductDto>(c)).ToList();
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
        public async Task<ServiceResponse<IEnumerable<GetProductDto?>>> GetInRange(double top, double down)
        {
            var productList = await _repo.GetInRange(top, down);
            ServiceResponse<IEnumerable<GetProductDto>> response = new ServiceResponse<IEnumerable<GetProductDto>>();
            response.Data = productList.Select(c => _mapper.Map<GetProductDto>(c)).ToList();
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
        public async Task<ServiceResponse<IEnumerable<GetProductDto?>>> GetByCategory(int categoryId)
        {
            var productList = await _repo.GetByCategory(categoryId);
            ServiceResponse<IEnumerable<GetProductDto>> response = new ServiceResponse<IEnumerable<GetProductDto>>();
            response.Data = productList.Select(c => _mapper.Map<GetProductDto>(c)).ToList();
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
        public async Task<ServiceResponse<GetProductDto>> Add(AddProductDto product)
        {
            //if (product == null) return null;
            var mapProduct = _mapper.Map<Product>(product);
            var checkName = await _repo.GetList(mapProduct.Name, 1);
 
            ServiceResponse<GetProductDto> response = new ServiceResponse<GetProductDto>();

            if (checkName.Count() > 0)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Duplicate Name!!!!";
                return response;
            }
            var createdProduct = await _repo.Add(mapProduct);
            response.Data = _mapper.Map<GetProductDto?>(createdProduct);
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

        public async Task<ServiceResponse<GetProductDto>> Update(AddProductDto updateProduct, int id)
        {
            //var mapProduct = _mapper.Map<Product>(updateProduct);
            var updatedProduct = await _repo.Update(updateProduct, id);
            ServiceResponse<GetProductDto> response = new ServiceResponse<GetProductDto>();
            response.Data = _mapper.Map<GetProductDto?>(updatedProduct);
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

        public async Task<ServiceResponse<GetProductDto>> Delete(int id)
        {
            var deletedProduct = await _repo.Delete(id);
            ServiceResponse<GetProductDto> response = new ServiceResponse<GetProductDto>();
            response.Data = _mapper.Map<GetProductDto?>(deletedProduct);
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
