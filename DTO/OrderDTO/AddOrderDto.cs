using System.ComponentModel.DataAnnotations.Schema;

namespace TEST_CRUD.DTO.OrderDTO
{
    public class AddOrderDto
    {
        public string Order_Number { get; set; }
        public int Customer_Id { get; set; }
        public int Address_Id { get; set; }
        public List<AddProductOrderDto> ProductLists { get; set; }
       
    }
}
