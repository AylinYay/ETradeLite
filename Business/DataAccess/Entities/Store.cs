#nullable disable

using AppCore.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.DataAccess.Entities
{
    public partial class Store : Record
    {
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(150)]
        [DisplayName("Store Name")]
        public string Name { get; set; }


        [DisplayName("Virtual")]
        public bool IsVirtual { get; set; }
    }
    
    public partial class Store
    {
        [NotMapped]
        [DisplayName("Virtual")]
        public string IsVirtualDisplay { get; set; }
    }

}
