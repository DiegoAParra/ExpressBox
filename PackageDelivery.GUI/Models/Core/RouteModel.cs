using System.ComponentModel;

namespace PackageDelivery.GUI.Models.Core
{
    public class RouteModel
    {
        public long Id { get; set; }

        [DisplayName("Paquete")]
        public long Id_Package { get; set; }

        [DisplayName("Descripción")]
        public string Description { get; set; }

        [DisplayName("Dirección")]
        public string DestinationAddress { get; set; }
    }
}