using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X9;
using System;
using TEST_CRUD.Data;
using TEST_CRUD.Models;

namespace TEST_CRUD.Repositories.Payments
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly CyberSharkContext appDbContext;
        public async Task<Payment?> Add(Payment payment)
        {
            payment.Payment_Id = "PM" + DateTime.Now.Ticks.ToString();
            payment.Status = "Unpaid";
            payment.Payment_Url = "";
            payment.Order_Number = "OD" + DateTime.Now.Ticks.ToString();
            payment.Status = "Unpaid";
            if (payment.Type == "VnPay")
            {
                string vnp_Returnurl = "http://localhost:7255/vnpay_return"; //URL nhan ket qua tra ve 
                string vnp_Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html"; //URL thanh toan cua VNPAY 
                string vnp_TmnCode = "KD7TU78B"; //Ma website
                string vnp_HashSecret = "FVJVBAWVSSDRXZOETVFTWWQNOKMREOVP"; //Chuoi bi mat
                var CreatedDate = DateTime.Now;
                DateTime expired = DateTime.Now.AddMinutes(15);
                string locale = "";
                //Build URL for VNPAY
                VnPayLibrary vnpay = new VnPayLibrary();
                vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
                vnpay.AddRequestData("vnp_Command", "pay");
                vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
                vnpay.AddRequestData("vnp_Amount", (payment.Amount * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
                vnpay.AddRequestData("vnp_BankCode", "NCB");
                vnpay.AddRequestData("vnp_CreateDate", CreatedDate.ToString("yyyyMMddHHmmss"));
                vnpay.AddRequestData("vnp_CurrCode", "VND");
                vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());
                if (!string.IsNullOrEmpty(locale))
                {
                    vnpay.AddRequestData("vnp_Locale", locale);
                }
                else
                {
                    vnpay.AddRequestData("vnp_Locale", "vn");
                }
                vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + payment.Order_Number);
                vnpay.AddRequestData("vnp_OrderType", "Other"); //default value: other
                vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
                vnpay.AddRequestData("vnp_TxnRef", payment.Order_Number); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày
                vnpay.AddRequestData("vnp_ExpireDate", expired.ToString("yyyyMMddHHmmss"));
                payment.Payment_Url = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            }
            var addPayment = await appDbContext.Payment.AddAsync(payment);
            return addPayment.Entity;
        }

        public async Task<Payment?> GetByOrderId(string orderNumber)
        {
            /// test
            return await appDbContext.Payment.Where(b => b.IsDeleted == false).FirstOrDefaultAsync(p => p.Order_Number == orderNumber);
           
        }

        public async Task<bool> UpdatePaymentVnPay(VnpayReturn vnpay)
        {
            var result = await appDbContext.Payment.FirstOrDefaultAsync(od => od.Order_Number == vnpay.vnp_OrderInfo);
            result.Status = "Paid";
            await appDbContext.SaveChangesAsync();
            throw new NotImplementedException();
        }
    }
}
