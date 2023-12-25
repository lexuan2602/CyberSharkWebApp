using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TEST_CRUD.EntityFramework.Entity.Base;

namespace TEST_CRUD.Models
{
    public class Order : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("order_number")]
        public string Order_Number {  get; set; }
        
        [ForeignKey("Customer")]
        [Column("customer_id")]
        public int Customer_Id { get; set; }

        [ForeignKey("Address")]
        [Column("address_id")]
        public int Address_Id { get; set; }

        [Column("order_detail")]
        public string? Order_Detail { get; set; }

        [Column("cost")]
        public double? Cost { get; set; }

        [Column("status")]
        public string Status { get; set; } = "Unpaid";

        [Column("discount_amount")]
        public double? Discount_Amount { get; set; }

        [Column("date_deleted")]
        public DateTime? Date_Deleted { get; set; }

        [Column("date_created")]
        public DateTime? Date_Created { get; set; } = DateTime.Now;

        [Column("date_modied")]
        public DateTime? Date_Modified { get; set; } = DateTime.Now;
        public Customer Customer { get; set; }
        public Address Address { get; set; }
 
        public ICollection<VoucherOrders> VoucherOrders { get; set; }


    }
}
