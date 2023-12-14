using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TEST_CRUD.DTO.AddressDTO
{
    public class AddAddressDto 
    {
        public int Customer_Id { get; set; }
        public string? Address_Street { get; set; }
        public string? Address_District { get; set; }
        public string? Address_City { get; set; }
        public string? Address_Country { get; set; }
        public string? Receiver_Name { get; set; }
        public string? Receiver_Telephone { get; set; }
        public int Is_Default { get; set; } = 1;
    }
}
