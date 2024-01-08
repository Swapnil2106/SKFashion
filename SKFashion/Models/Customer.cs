using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKFashion.Models
{
    public class Customer
    {
        [Key]                                                           //to make CustomerId as the Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]           //to auto-generate the Customerid from the database
        public int CustomerId { get; set; }
        [StringLength(50)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        public long PhoneNumber { get; set; }
        [StringLength(10)]
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        [ForeignKey("AddressId")]
        public int AddressId { get; set; }

        public Address? Address { get; set; }
    }
}
