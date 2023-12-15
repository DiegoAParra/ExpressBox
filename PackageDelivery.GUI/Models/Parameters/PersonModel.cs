
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class PersonModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Primer Nombre")]
        public string FirstName { get; set; }
        [DisplayName("Otros Nombres")]
        public string OtherNames { get; set; }
        [Required]
        [DisplayName("Primer Apellido")]
        public string FirstLastName { get; set; }
        [DisplayName("Segundo Apellido")]
        public string SecondLastName { get; set; }
        [Required]
        [DisplayName("Identificacion")]
        public string IdentificationNumber { get; set; }
        [Required]
        [DisplayName("Celular")]
        public string CellPhone { get; set; }
        [Required]
        [DisplayName("Correo Electronico")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Tipo de Documento")]
        public int Id_DocumentType { get; set; }

        [DisplayName("Tipo de Documento")]
        public string DocumentTypeName { get; set; }

        public IEnumerable<DocumentTypeModel> DocumentTypeList { get; set; }
    }
}
