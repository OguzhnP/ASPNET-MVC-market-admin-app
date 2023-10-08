using Mopas.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mopas.Models
{
    public class SalesReportViewModel
    {
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
        public List<int> SelectedProductIds { get; set; } // Seçilen Product'ların Id'leri

        public ICollection<Product> Products { get; set; } // Tüm Product'lar için liste

        public SalesReportViewModel()
        {
            SelectedProductIds = new List<int>();
        }
    }
}
