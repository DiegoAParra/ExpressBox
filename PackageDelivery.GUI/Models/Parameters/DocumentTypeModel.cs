
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class DocumentTypeModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Tipo de Documento")]
        public string Name { get; set; }
    }
}
