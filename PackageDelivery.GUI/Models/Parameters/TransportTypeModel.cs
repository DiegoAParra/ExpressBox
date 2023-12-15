using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class TransportTypeModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Tipo de Transporte")]
        public string Name { get; set; }

    }
     
}