using System.ComponentModel.DataAnnotations;

namespace Mopas.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string CategoryName { get; set; }

        public ICollection<Product> Products{ get; set; }
    }
}
