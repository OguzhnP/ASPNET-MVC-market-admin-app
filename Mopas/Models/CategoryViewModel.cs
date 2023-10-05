using System.ComponentModel.DataAnnotations;

namespace Mopas.Models
{
    public class CategoryViewModel
    {
        [Required]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter olmalıdır")]
        public string CategoryName { get; set; }
    }
}
