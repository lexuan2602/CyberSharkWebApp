using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TEST_CRUD.EntityFramework.Entity.Base;

namespace TEST_CRUD.Models
{
    public class VoucherOrders : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Order")]
        [Column("order_id")]
        public int Order_Id { get; set; }

        [ForeignKey("Voucher")]
        [Column("voucher_id")]
        public int Voucher_Id { get; set; }

        [Column("date_deleted")]
        public DateTime? Date_Deleted { get; set; }
        [Column("date_created")]
        public DateTime Date_Created { get; set; } = DateTime.Now;
        [Column("date_modied")]
        public DateTime Date_Modified { get; set; } = DateTime.Now;

        public Voucher Voucher { get; set; }
        public Order Order { get; set; }

    }
}
