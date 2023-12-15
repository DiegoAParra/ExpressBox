
using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class DocumentTypeApplicationMapper : DTOMapperBase<DocumentTypeDTO, DocumentTypeDbModel>
    {
        public override DocumentTypeDTO DbModelToDTOMapper(DocumentTypeDbModel input)
        {
            return new DocumentTypeDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<DocumentTypeDTO> DbModelToDTOMapper(IEnumerable<DocumentTypeDbModel> input)
        {
            IList<DocumentTypeDTO> list = new List<DocumentTypeDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override DocumentTypeDbModel DTOToDbModelMapper(DocumentTypeDTO input)
        {
            return new DocumentTypeDbModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<DocumentTypeDbModel> DTOToDbModelMapper(IEnumerable<DocumentTypeDTO> input)
        {
            IList<DocumentTypeDbModel> list = new List<DocumentTypeDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
