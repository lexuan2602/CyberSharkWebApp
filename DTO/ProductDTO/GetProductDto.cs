namespace TEST_CRUD.DTO.ProductDTO
{
    public class GetProductDto
    {
        public string? Name { get; set; }
        public double? Cost_Price { get; set; }
        public double? Sale_Price { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public string? Product_Images { get; set; }
        public int Category_Id { get; set; }
        public int Brand_Id { get; set; }
    }
}
