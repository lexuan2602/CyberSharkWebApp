using TEST_CRUD.DTO;
using TEST_CRUD.DTO.PaymentDTO;

namespace TEST_CRUD.Services.Payments
{
    public interface IPaymentService
    {
        Task<ServiceResponse<GetPaymentDto?>> GetByOrderId(string orderId);
        Task<ServiceResponse<GetPaymentDto?>> Add(AddPaymentDto payment);
    }
}
