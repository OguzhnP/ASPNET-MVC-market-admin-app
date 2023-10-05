using System.ComponentModel.DataAnnotations;

namespace Mopas.Models
{
    public class ProductViewModel
    {

        [Required]
        [StringLength(30, ErrorMessage ="ProductName en fazla 30 karakter olmalıdır")]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
