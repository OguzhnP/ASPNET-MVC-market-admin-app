using System.ComponentModel.DataAnnotations;

namespace Mopas.Entities
{
    public class SalesReport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string SalesName{ get; set; }
        public DateTime SalesDate{ get; set; } 
        public ICollection<Product>  Products { get; set; }

        public decimal SalesQuantity { get; set; }
    }
}
