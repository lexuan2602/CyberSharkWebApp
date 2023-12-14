using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TEST_CRUD.EntityFramework.Entity.Base;

namespace TEST_CRUD.Models
{
    public class Cart : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        [Column("customer_id")]
        public int Customer_Id { get; set; }

        [Column("cart_detail")]
        public string? Cart_Detail { get; set; } = "";

        [Column("cart_number_item")] // number of item
        public double? Cart_Number_Item { get; set; }

        [Column("cart_total")] // price
        public double? Cart_Total { get; set; }

        [Column("date_deleted")]
        public DateTime? Date_Deleted { get; set; }

        [Column("date_created")]
        public DateTime? Date_Created { get; set; } = DateTime.Now;

        [Column("date_modied")]
        public DateTime? Date_Modified { get; set; } = DateTime.Now;
        public Customer Customer { get; set; }
        
        

    }
}
