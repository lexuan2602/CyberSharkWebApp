using AutoMapper;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.AddressDTO;
using TEST_CRUD.DTO.CategoryDTO;
using TEST_CRUD.DTO.CustomerDTO;
using TEST_CRUD.DTO.ProductDTO;

namespace TEST_CRUD
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Brand, GetBrandDto>();
            CreateMap<AddBrandDto, Brand>();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<AddCategoryDto, Category>();
            CreateMap<Product, GetProductDto>();
            CreateMap<AddProductDto, Product>();
            CreateMap<Customer, GetCustomerDto>();
            CreateMap<AddCustomerDto, Customer>();
            CreateMap<Address, GetAddressDto>();
            CreateMap<AddAddressDto, Address>();

        }
    }
}
