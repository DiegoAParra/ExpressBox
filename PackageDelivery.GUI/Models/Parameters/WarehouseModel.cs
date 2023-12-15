using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class WarehouseModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Dirección")]
        public string Direction { get; set; }
        [Required]
        [DisplayName("Código")]
        public string Code { get; set; }

        [DisplayName("Latitud")]
        public string Latitude { get; set; }

        [DisplayName("Longitud")]
        public string Longitude { get; set; }

        [DisplayName("Ciudad")]
        public long Id_City { get; set; }

        [DisplayName("Ciudad")]
        public string CityName { get; set; }
        public IEnumerable<CityModel> CityList { get; set; }
    }
}