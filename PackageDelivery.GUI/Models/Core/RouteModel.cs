using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        [DisplayName("Hora Entrega")]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public DateTime DepurateDate { get; set; }
    }
}