using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.OrderDTO;
using TEST_CRUD.Models;
using TEST_CRUD.Repositories;
using TEST_CRUD.Repositories;

namespace TEST_CRUD.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepo, IMapper mapper)
        {
            _repo = orderRepo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetOrderDto?>> Add(AddOrderDto order)
        { 
            
            ServiceResponse<GetOrderDto> response = new ServiceResponse<GetOrderDto>();         
            response.Data = await _repo.Add(order);
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

        public async Task<ServiceResponse<GetOrderDto?>> GetByCustomerId(int customerId)
        {
            ServiceResponse<GetOrderDto> response = new ServiceResponse<GetOrderDto>();
            response.Data = await _repo.GetByCustomerId(customerId);
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

        public async Task<ServiceResponse<GetOrderDto?>> GetById(int orderid)
        {
            ServiceResponse<GetOrderDto> response = new ServiceResponse<GetOrderDto>();
            response.Data = await _repo.GetById(orderid);
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

        public async Task<ServiceResponse<IEnumerable<GetOrderDto?>>> GetList(string search)
        {
            var orderList = await _repo.GetList(search);
            ServiceResponse<IEnumerable<GetOrderDto>> response = new ServiceResponse<IEnumerable<GetOrderDto>>();
            response.Data = orderList.Select(c => _mapper.Map<GetOrderDto>(c)).ToList();
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

        public async Task<ServiceResponse<GetOrderDto?>> UpdateOrderStatus(int id, string status)
        {
            ServiceResponse<GetOrderDto> response = new ServiceResponse<GetOrderDto>();
            response.Data = await _repo.UpdateOrderStatus(id, status);
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
