using System.ComponentModel.DataAnnotations.Schema;

namespace TEST_CRUD.DTO.OrderDTO
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public string Order_Number { get; set; }
        public int Customer_Id { get; set; }
        public int Address_Id { get; set; }
        public string? Order_Detail { get; set; }
        public double? Cost { get; set; }
        public string Status { get; set; } 
    }
}
