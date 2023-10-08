using Mopas.Entities;
using System.ComponentModel.DataAnnotations;

namespace Mopas.Models
{
    public class SalesReportViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string SalesName { get; set; }

        [Required]
        [Display(Name = "Sales Date")]
        public DateTime SalesDate { get; set; }

        [Required]
        [Display(Name = "Sales Quantity")]
        public decimal SalesQuantity { get; set; }

        [Display(Name = "Selected Products")]
        public List<int> SelectedProductIds { get; set; }  

        public ICollection<Product> Products { get; set; } 

        public SalesReportViewModel()
        {
            SelectedProductIds = new List<int>();
        }
    }
}
