using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TEST_CRUD.EntityFramework.Entity.Base;

namespace TEST_CRUD.Models
{
    public class Voucher : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Name must be between 6 and 100 characters")]
        [Column("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Percent is required")]
        [Range(0.0, 100.0, ErrorMessage = "Voucher Discount must be between 0 and 100")]
        [Column("percent")]
        public double Percent { get; set; }

        [Column("date_expired")]
        public DateTime? Date_Expired { get; set; }

        [Column("date_deleted")]
        public DateTime? Date_Deleted { get; set; }

        [Column("date_created")]
        public DateTime Date_Created { get; set; } = DateTime.Now;

        [Column("date_modied")]
        public DateTime Date_Modified { get; set; } = DateTime.Now;

        public ICollection<VoucherOrders> VoucherOrders { get; set; }

    }
}
