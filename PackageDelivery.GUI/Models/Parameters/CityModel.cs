using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class CityModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Ciudad")]
        public string Name { get; set; }

        [DisplayName("Departamento")]
        public long Id_Department { get; set; }

        [DisplayName("Departamento")]
        public string DepartmentName { get; set; }
        
        public IEnumerable<DepartmentModel> DepartmentList { get; set; }
    }
}