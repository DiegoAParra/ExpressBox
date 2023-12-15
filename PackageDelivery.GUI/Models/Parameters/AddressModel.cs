
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class AddressModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Es la Actual")]
        public bool Current { get; set; }

        [Required]
        [DisplayName("Tipo de Calle")]
        public string StreetType { get; set; }

        [Required]
        [DisplayName("Número")]
        public string Number { get; set; }

        [Required]
        [DisplayName("Tipo de Propiedad")]
        public string PropertyType { get; set; }

        [Required]
        [DisplayName("Barrio")]
        public string Neighborhood { get; set; }

        [DisplayName("Observaciones")]
        public string Observations { get; set; }

        [DisplayName("Persona")]
        public long Id_Person { get; set; }

        [DisplayName("Ciudad")]
        public long Id_City { get; set; }

        [DisplayName("Persona")]
        public string PersonName { get; set; }

        [DisplayName("Ciudad")]
        public string CityName { get; set; }
        public IEnumerable<CityModel> CityList { get; set; }
        public IEnumerable<PersonModel> PersonList { get; set; }

    }
}