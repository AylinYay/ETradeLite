#nullable disable

using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace Business.DataAccess.Entities
{
    public class Category : Record
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }   // Bir category'de birden çok ürün olabilir.
    }
}
