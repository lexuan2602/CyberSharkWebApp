using AutoMapper;
using TEST_CRUD.DTO;

namespace TEST_CRUD
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Brand, GetBrandDto>();
            CreateMap<AddBrandDto, Brand>();

        }
    }
}
