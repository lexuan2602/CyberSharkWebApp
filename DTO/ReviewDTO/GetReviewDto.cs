namespace TEST_CRUD.DTO.ReviewDTO
{
    public class GetReviewDto
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public int Product_Id { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; }
        public string Review_Images { get; set; }
    }
}
