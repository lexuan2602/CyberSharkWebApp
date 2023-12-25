using Microsoft.AspNetCore.Mvc;
using TEST_CRUD.DTO;

namespace TEST_CRUD.Services
{
    public interface IBrandService
    {
        Task<ServiceResponse<IEnumerable<GetBrandDto?>>> GetList(string search, int page);
        Task<ServiceResponse<GetBrandDto?>> GetById(int brandid);
        Task<ServiceResponse<GetBrandDto?>> Add(AddBrandDto brand);
        Task<ServiceResponse<GetBrandDto?>> Update(AddBrandDto brand, int brandid);
        Task<ServiceResponse<GetBrandDto?>> Delete(int brandid);
    }
}
