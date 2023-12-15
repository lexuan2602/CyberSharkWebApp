using AutoMapper;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.PaymentDTO;
using TEST_CRUD.Models;
using TEST_CRUD.Repositories.Payments;

namespace TEST_CRUD.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repo;
        private readonly IMapper _mapper;
        public PaymentService(IPaymentRepository paymentRepo, IMapper mapper)
        {
            _repo = paymentRepo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetPaymentDto?>> Add(AddPaymentDto payment)
        {
            var mapPayment = _mapper.Map<Payment>(payment);
           
            ServiceResponse<GetPaymentDto> response = new ServiceResponse<GetPaymentDto>();

            var createdPayment = await _repo.Add(mapPayment);
            response.Data = _mapper.Map<GetPaymentDto?>(createdPayment);
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

        

        public async Task<ServiceResponse<GetPaymentDto?>> GetByOrderId(string orderId)
        {
            var getPayment = await _repo.GetByOrderId(orderId);
            ServiceResponse<GetPaymentDto> response = new ServiceResponse<GetPaymentDto>();
            response.Data = _mapper.Map<GetPaymentDto?>(getPayment);
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
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetPaymentDto?>> UpdatePaymentVnPay(VnpayReturn vnpay)
        {
            var getPayment = await _repo.UpdatePaymentVnPay(vnpay);
            ServiceResponse<GetPaymentDto> response = new ServiceResponse<GetPaymentDto>();
            response.Data = _mapper.Map<GetPaymentDto?>(getPayment);
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
            throw new NotImplementedException();
        }



    }
}
