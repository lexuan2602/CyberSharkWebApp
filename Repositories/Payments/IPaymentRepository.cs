using TEST_CRUD.DTO;

namespace TEST_CRUD.Repositories.Payments
{
    public interface IPaymentRepository
    {
        public Task<Payment?> GetByOrderId(string order_id);
        public Task<Payment?> Add(Payment payment);

        public Task<bool> UpdatePaymentVnPay(VnpayReturn vnpay);
        
    }
}
