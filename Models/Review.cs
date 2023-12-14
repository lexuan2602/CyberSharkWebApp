using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TEST_CRUD.EntityFramework.Entity.Base;

namespace TEST_CRUD.Models
{
    public class Review : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        [Column("customer_id")]
        public int Customer_Id { get; set; }

        [ForeignKey("Product")]
        [Column("product_id")]
        public int Product_Id { get; set; }

        [Required]
        [Column("rating")]
        public int Rating { get; set; }

        [Required]
        [Column("content")]
        public string Content { get; set; }

        [Required]
        [Column("review_images")]
        public string Review_Images { get; set; }

        [Column("date_deleted")]
        public DateTime? Date_Deleted { get; set; }
        [Column("date_created")]
        public DateTime Date_Created { get; set; } = DateTime.Now;
        [Column("date_modied")]
        public DateTime Date_Modified { get; set; } = DateTime.Now;

        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
