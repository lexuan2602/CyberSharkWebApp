using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TEST_CRUD.DTO.PaymentDTO
{
    public class AddPaymentDto
    {

        public int Customer_Id { get; set; }
        public int Order_Id { get; set; }
        public string Type { get; set; }
        public double? Amount { get; set; }
 
    }
}
