using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TEST_CRUD.EntityFramework.Entity.Base;

namespace TEST_CRUD.Models
{
    public class Product : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 6,  ErrorMessage = "Name must be between 6 and 100 characters")]
        [Column("name")]
        public string? Name { get; set; }
        
        
        [Column("cost_price")]
        public double? Cost_Price { get; set; }

        [Column("sale_price")]
        public double? Sale_Price { get; set; }

        [Column("description")]
        public string? Description { get; set; }


        [Column("quantity")]
        public string? Quantity { get; set; }

        [Column("product_images")]
        public string? Product_Images { get; set; }


        [ForeignKey("Category")]
        [Column("category_id")]
        public int Category_Id { get; set; }

        [ForeignKey("Brand")]
        [Column("brand_id")]
        public int Brand_Id { get; set; }

        [Column("date_deleted")]
        public DateTime? Date_Deleted { get; set; }
        [Column("date_created")]
        public DateTime Date_Created { get; set; }
        [Column("date_modied")]
        public DateTime Date_Modified { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }

      

    }
}
