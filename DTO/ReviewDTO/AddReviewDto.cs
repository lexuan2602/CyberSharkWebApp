using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TEST_CRUD.DTO.ReviewDTO
{
    public class AddReviewDto
    {
        public int Customer_Id { get; set; }
        public int Product_Id { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; }
        public string Review_Images { get; set; }
    }
}
