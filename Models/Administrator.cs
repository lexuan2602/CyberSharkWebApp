using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TEST_CRUD.EntityFramework.Entity.Base;

namespace TEST_CRUD.Models
{
    public class Administrator : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Name must be between 6 and 100 characters")]
        [Column("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
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

        [Column("admin_type")]
        public string? Admin_Type { get; set; }

        [Column("admin_images")]
        public string? Admin_Images { get; set; }

        [Column("date_deleted")]
        public DateTime? Date_Deleted { get; set; }

        [Column("date_created")]
        public DateTime? Date_Created { get; set; } = DateTime.Now;

        [Column("date_modied")]
        public DateTime? Date_Modified { get; set; } = DateTime.Now;
    }
}
