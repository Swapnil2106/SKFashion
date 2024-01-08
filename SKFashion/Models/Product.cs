using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKFashion.Models
{
    public class Product
    {
        [Key]                                                           //to make CustomerId as the Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]           //to auto-generate the Customerid from the database
        public int ProductId { get; set; }
        [StringLength(150)]
        public string? ProductName { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        [StringLength(300)]
        public string? Description { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
