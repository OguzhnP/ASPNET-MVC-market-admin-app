using Mopas.Entities;
using System.ComponentModel.DataAnnotations;

namespace Mopas.Models
{
    public class SalesReportViewModel
    {
        [Required]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter olmalıdır")]
        public string SalesName { get; set; }
        public DateTime SalesDate { get; set; }
        public ICollection<Product> Products { get; set; }

        public decimal SalesQuantity { get; set; }
    }
}
