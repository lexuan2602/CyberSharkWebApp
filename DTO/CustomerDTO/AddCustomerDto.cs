using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TEST_CRUD.DTO.CustomerDTO
{
    public class AddCustomerDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Sex { get; set; }
        public string? Telephone { get; set; }
        public DateTime? Date_Of_Birth { get; set; }
        public string? Customer_Images { get; set; }
        public int? Accumulate_Point { get; set; }
        public string? Type { get; set; }
    }
}
