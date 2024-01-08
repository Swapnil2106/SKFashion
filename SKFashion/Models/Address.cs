using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKFashion.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        public int BuildingNumber { get; set; }
        [StringLength(150)]
        public string? StreetAddress { get; set; }
        [StringLength(20)]
        public string? City { get; set; }
        [StringLength(20)]
        public string? State { get; set; }
        [StringLength(20)]
        public string? Country { get; set; }
        public long PinCode { get; set; }
    }
}
