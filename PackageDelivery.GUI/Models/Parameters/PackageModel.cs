using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class PackageModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Peso (kg)")]
        public int Weight { get; set; }
        [Required]
        [DisplayName("Profundo (cm)")]
        public int Depth { get; set; }
        [Required]
        [DisplayName("Ancho (cm)")]
        public int Width { get; set; }
        [Required]
        [DisplayName("Alto (cm)")]
        public int Height { get; set; }

        [DisplayName("Oficina")]
        public long Id_Office { get; set; }

        [DisplayName("Oficina")]
        public string OfficeName { get; set; }
        public IEnumerable<OfficeModel> OfficeList { get; set; }
    }
}