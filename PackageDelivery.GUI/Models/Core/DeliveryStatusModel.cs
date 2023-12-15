using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class DeliveryStatusModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Nombre del Estado")]
        public string Name { get; set; }
    }
}