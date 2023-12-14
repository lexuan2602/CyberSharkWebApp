using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TEST_CRUD.DTO;
using TEST_CRUD.Repositories;

namespace TEST_CRUD.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repo;
        private readonly IMapper _mapper;
        public BrandService(IBrandRepository brandRepo, IMapper mapper)
        {
            _repo = brandRepo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetBrandDto>> GetById(int id)
        {
            var getBrand = await _repo.GetById(id);
            ServiceResponse<GetBrandDto> response = new ServiceResponse<GetBrandDto> ();
            response.Data = _mapper.Map<GetBrandDto?>(getBrand);
            if(response.Data != null)
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
        public async Task<ServiceResponse<IEnumerable<GetBrandDto?>>> GetList(string search, int page)
        {
            var brandList = await _repo.GetList(search);
            ServiceResponse<IEnumerable<GetBrandDto>> response = new ServiceResponse<IEnumerable<GetBrandDto>>();
            response.Data = brandList.Select(c => _mapper.Map<GetBrandDto>(c)).ToList();
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
        public async Task<ServiceResponse<GetBrandDto>> Add(AddBrandDto brand)
        {
            //if (brand == null) return null;
            var mapBrand = _mapper.Map<Brand>(brand);
            var checkName = await _repo.GetList(mapBrand.Name);
            ServiceResponse<GetBrandDto> response = new ServiceResponse<GetBrandDto>();

            if (checkName.Count() > 0)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Duplicate Name!!!!";
                return response;
            }
            var createdBrand = await _repo.Add(mapBrand);
            response.Data = _mapper.Map<GetBrandDto?>(createdBrand);
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

        public async Task<ServiceResponse<GetBrandDto>> Update(AddBrandDto updateBrand,int id)
        {
            //var mapBrand = _mapper.Map<Brand>(updateBrand);
            var updatedBrand = await _repo.Update(updateBrand, id);
            ServiceResponse<GetBrandDto> response = new ServiceResponse<GetBrandDto>();
            response.Data = _mapper.Map<GetBrandDto?>(updatedBrand);
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

        public async Task<ServiceResponse<GetBrandDto>> Delete(int id)
        {
            var deletedBrand = await _repo.Delete(id);
            ServiceResponse<GetBrandDto> response = new ServiceResponse<GetBrandDto>();
            response.Data = _mapper.Map<GetBrandDto?>(deletedBrand);
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
