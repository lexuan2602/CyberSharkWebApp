using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TEST_CRUD.DTO.PaymentDTO
{
    public class GetPaymentDto
    {
        public string Payment_Id { get; set; }
        public int Customer_Id { get; set; }
        public int Order_Id { get; set; }
        public string Type { get; set; }
        public double? Amount { get; set; }
        public string? Status { get; set; }
    }
}
