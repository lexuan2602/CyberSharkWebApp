using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TEST_CRUD.EntityFramework.Entity.Base;

namespace TEST_CRUD.Models
{
    public class Payment : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("payment_id")]
        public string Payment_Id {  get; set; }

        [ForeignKey("Customer")]
        [Column("customer_id")]
        public int Customer_Id { get; set; }

       
        [Column("order_number")]
        public string Order_Number { get; set; }

        [Required(ErrorMessage = "Payment Type is required")]
        [Column("type")]
        public string Type { get; set; }

        [Column("amount")]
        public double? Amount { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("payment_url")]
        public string? Payment_Url { get; set; } = "Unpaid";


        [Column("date_deleted")]
        public DateTime? Date_Deleted { get; set; }

        [Column("date_created")]
        public DateTime? Date_Created { get; set; } = DateTime.Now;

        [Column("date_modied")]
        public DateTime? Date_Modified { get; set; } = DateTime.Now;

        public Customer Customer { get; set; }

        public Order Order { get; set; }
    }
}
