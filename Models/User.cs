using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TEST_CRUD.Models
{
    [Table("users")] // Sử dụng [Table] Attribute để ánh xạ tới bảng "users"
    public class User
    {
        [Key] // Sử dụng [Key] Attribute để xác định khóa chính
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        [StringLength(45)]
        [Column("Ten")] // Sử dụng [Column] Attribute để ánh xạ tới cột "Ten" trong bảng
        public string? Ten { get; set; } = "";

        [Required(ErrorMessage = "Password is a required field.")]
        [StringLength(64)]
        [Column("Mat_khau")] // Ánh xạ tới cột "Mat_khau"
        public string Mat_khau { get; set; } = "";

        [Required(ErrorMessage = "Email is a required field.")]
        [StringLength(255)]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Column("Email")] // Ánh xạ tới cột "Email"
        public string Email { get; set; } = "";

        [StringLength(15)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Invalid phone number.")]
        [Column("So_dien_thoai")] // Ánh xạ tới cột "So_dien_thoai"
        public string So_dien_thoai { get; set; } = "";

        [StringLength(255)]
        [Column("Hinhanh")] // Ánh xạ tới cột "Hinhanh"
        public string Hinhanh { get; set; } = "";

        [StringLength(255)]
        [Column("Role")] // Ánh xạ tới cột "Role"
        public string Role { get; set; } = "";

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
