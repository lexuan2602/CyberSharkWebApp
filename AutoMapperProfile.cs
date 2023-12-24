using AutoMapper;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.AddressDTO;
using TEST_CRUD.DTO.BlogDTO;
using TEST_CRUD.DTO.CategoryDTO;
using TEST_CRUD.DTO.CustomerDTO;
using TEST_CRUD.DTO.PaymentDTO;
using TEST_CRUD.DTO.ProductDTO;
using TEST_CRUD.DTO.ReviewDTO;
using TEST_CRUD.DTO.VoucherDTO;

namespace TEST_CRUD
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            ///////////BRAND///////////////
            CreateMap<Brand, GetBrandDto>();
            CreateMap<AddBrandDto, Brand>();
            ///////////CATEGORY///////////////
            CreateMap<Category, GetCategoryDto>();
            CreateMap<AddCategoryDto, Category>();
            ///////////PRODUCT///////////////
            CreateMap<Product, GetProductDto>();
            CreateMap<AddProductDto, Product>();
            ///////////CUSTOMER///////////////
            CreateMap<Customer, GetCustomerDto>();
            CreateMap<AddCustomerDto, Customer>();
            ///////////ADDRESS///////////////
            CreateMap<Address, GetAddressDto>();
            CreateMap<AddAddressDto, Address>();
            ///////////PAYMENT///////////////
            CreateMap<Payment, GetPaymentDto>();
            CreateMap<AddPaymentDto, Payment>();
            ///////////BLOG///////////////
            CreateMap<Blog, GetBlogDto>();
            CreateMap<AddBlogDto, Blog>();
            ///////////REVIEW///////////////
            CreateMap<Review, GetReviewDto>();
            CreateMap<AddReviewDto, Review>();

            ///////////VOucher///////////////
            CreateMap<Voucher, GetVoucherDto>();
            CreateMap<AddVoucherDto, Voucher>();


        }
    }
}
