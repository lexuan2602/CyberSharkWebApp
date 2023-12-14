namespace TEST_CRUD.DTO.OrderDTO
{
    public class GetProductOrderDto
    {
        public int? Product_Id { get; set; }
        public string? Product_Name { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
    }
}
