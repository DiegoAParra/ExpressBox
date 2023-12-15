using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Implementation.Mappers.Parameters
{
    public class DocumentTypeGUIMapper : ModelMapperBase<DocumentTypeModel, DocumentTypeDTO>
    {
        public override DocumentTypeModel DTOToModelMapper(DocumentTypeDTO input)
        {
            return new DocumentTypeModel()
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<DocumentTypeModel> DTOToModelMapper(IEnumerable<DocumentTypeDTO> input)
        {
            IList<DocumentTypeModel> list = new List<DocumentTypeModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override DocumentTypeDTO ModelToDTOMapper(DocumentTypeModel input)
        {
            return new DocumentTypeDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<DocumentTypeDTO> ModelToDTOMapper(IEnumerable<DocumentTypeModel> input)
        {
            IList<DocumentTypeDTO> list = new List<DocumentTypeDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}