using PackageDelivery.GUI.Models.Parameters;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class PackageHistoryModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Fecha de Admisión")]
        public DateTime AdmissionDate { get; set; }
        [Required]
        [DisplayName("Fecha de Entrega")]
        public DateTime DepurateDate { get; set; }

        [DisplayName("Descripción")]
        public string Description { get; set; }

        [DisplayName("Paquete")]
        public long Id_Package { get; set; }

        [DisplayName("Bodega")]
        public long Id_Warehouse { get; set; }

        [DisplayName("Paquete")]
        public string PackageName { get; set; }

        [DisplayName("Bodega")]
        public string WarehouseName { get; set; }
        public IEnumerable<PackageModel> PackageList { get; set; }

        public IEnumerable<WarehouseModel> WarehouseList { get; set; }
    }
}