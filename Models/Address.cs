using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TEST_CRUD.EntityFramework.Entity.Base;

namespace TEST_CRUD.Models
{
    public class Address : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        [Column("customer_id")]
        public int Customer_Id { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [Column("address_street")]
        [StringLength(20)]
        public string? Address_Street { get; set; }

        [Required(ErrorMessage = "District is required")]
        [Column("address_district")]
        [StringLength(20)]
        public string? Address_District { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Column("address_city")]
        [StringLength(20)]
        public string? Address_City { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Column("address_country")]
        [StringLength(20)]
        public string? Address_Country { get; set; }

        [Required(ErrorMessage = "Receiver's Name is required")]
        [Column("receiver_name")]
        [StringLength(20)]
        public string? Receiver_Name { get; set; }

        [Required(ErrorMessage = "Receiver's Telephone is required")]
        [Column("receiver_telephone")]
        [StringLength(20)]
        public string? Receiver_Telephone { get; set; }

        [Column("is_default")]
        public int Is_Default { get; set; } = 1;

        [Column("date_deleted")]
        public DateTime? Date_Deleted { get; set; }

        [Column("date_created")]
        public DateTime? Date_Created { get; set; } = DateTime.Now;

        [Column("date_modied")]
        public DateTime? Date_Modified { get; set; } = DateTime.Now;
    }
}
