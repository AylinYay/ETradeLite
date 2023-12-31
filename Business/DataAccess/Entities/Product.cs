#nullable disable

using AppCore.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.DataAccess.Entities
{
    public partial class Product : Record
    {
        //[Required]
        [Required(ErrorMessage = "{0} is required!")]
        //[StringLength(200)]
        [MinLength(3, ErrorMessage = "{0} must be minimum {1} characters!")]
        [MaxLength(200, ErrorMessage = "{0} must be maximum {1} characters!")]
        public string Name { get; set; }

        [StringLength(300, ErrorMessage = "{0} must be maximum {1} characters!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Range(0, 1000000, ErrorMessage = "{0} must be between {1} and {2}!")]
        [DisplayName("Stock Amount")]
        public int? StockAmount { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} must be {1} or positive!")]
        [DisplayName("Unit Price")]
        public double? UnitPrice { get; set; }

        [DisplayName("Expiration Date")]
        public DateTime? ExpirationDate { get; set; }

        [DisplayName("Continued")]
        public bool IsContinued { get; set; }

        
        [DisplayName("Category")]
        public int? CategoryId { get; set; }

        public Category Category { get; set; } // Bir �r�nde bir category olabilir.
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
