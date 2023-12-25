using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TEST_CRUD.DTO.BlogDTO
{
    public class AddBlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Blog_Images { get; set; }
    }
}
