using System.ComponentModel.DataAnnotations.Schema;

namespace TEST_CRUD.DTO.CartDTO
{
    public class GetCartDto
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public string? Cart_Detail { get; set; } 
        public double? Cart_Number_Item { get; set; }
        public double? Cart_Total { get; set; }

    }
}
