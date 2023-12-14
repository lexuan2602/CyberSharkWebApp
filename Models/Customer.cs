using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TEST_CRUD.EntityFramework.Entity.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TEST_CRUD.Models
{
    public class Customer : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Name must be between 6 and 100 characters")]
        [Column("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Column("email")]
        public string Email { get; set; }

        [Column("sex")]
        [StringLength(20)]
        public string? Sex { get; set; }
        [Column("telephone")]
        [StringLength(20)]
        public string? Telephone { get; set; }

        [Column("date_of_birth")]
        public DateTime? Date_Of_Birth { get; set; }

        [Column("customer_images")]
        public string? Customer_Images { get; set; }

        [Column("accumulate_point")]
        public int? Accumulate_Point { get; set;}

        [Column("type")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Customer Type must be between 6 and 100 characters")]

        public string? Type { get; set; }

        [Column("date_deleted")]
        public DateTime? Date_Deleted { get; set; }

        [Column("date_created")]
        public DateTime Date_Created { get; set; } = DateTime.Now;

        [Column("date_modied")]
        public DateTime Date_Modified { get; set; } = DateTime.Now;
        //public ICollection<Product> Products { get; set; }
        public ICollection<Cart> Carts { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
