using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKFashion.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public DateTime OrderedDate { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public float TotalPrice { get; set; }
        public string? PaymentMethod { get; set; }

        public Customer? Customer { get; set; }
        public Product? Product { get; set; }
    }
}
