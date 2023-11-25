using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TEST_CRUD.DTO
{
    public class AddBrandDto
    {
        
        public string? Name { get; set; }
        public string? Brand_Image { get; set; }

    }
}
