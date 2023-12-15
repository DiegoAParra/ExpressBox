using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class DepartmentModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Departamento")]
        public string Name { get; set; }
    }
}