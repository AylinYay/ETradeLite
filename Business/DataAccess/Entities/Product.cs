#nullable disable

using AppCore.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.DataAccess.Entities
{
    public partial class Product : Record
    {
        [Required]
        //[StringLength(200)]
        [MinLength(3)]
        [MaxLength(200)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [Range(0, 1000000)]
        [DisplayName("Stock Amount")]
        public int StockAmount { get; set; }

        [Range(0, double.MaxValue)]
        [DisplayName("Unit Price")]
        public double UnitPrice { get; set; }

        [DisplayName("Expiration Date")]
        public DateTime? ExpirationDate { get; set; }

        [DisplayName("Continued")]
        public bool IsContinued { get; set; }

        [DisplayName("Category")]
        public int? CategoryId { get; set; }

        public Category Category { get; set; } // Bir üründe bir category olabilir.
    }

    public partial class Product
    {
        [NotMapped]
        [DisplayName("Unit Price")]
        public string UnitPriceDisplay { get; set; }

        [NotMapped]
        [DisplayName("Expiration Date")]
        public string ExpirationDateDisplay { get; set; }

        [NotMapped]
        [DisplayName("Is Continued")]
        public string IsContinuedDisplay { get; set; }
    }
}
