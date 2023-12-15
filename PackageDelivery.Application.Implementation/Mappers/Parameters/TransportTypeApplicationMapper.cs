using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class TransportTypeApplicationMapper : DTOMapperBase<TransportTypeDTO, TransportTypeDbModel>
    {
        public override TransportTypeDTO DbModelToDTOMapper(TransportTypeDbModel input)
        {
            return new TransportTypeDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<TransportTypeDTO> DbModelToDTOMapper(IEnumerable<TransportTypeDbModel> input)
        {
            IList<TransportTypeDTO> list = new List<TransportTypeDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override TransportTypeDbModel DTOToDbModelMapper(TransportTypeDTO input)
        {
            return new TransportTypeDbModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<TransportTypeDbModel> DTOToDbModelMapper(IEnumerable<TransportTypeDTO> input)
        {
            IList<TransportTypeDbModel> list = new List<TransportTypeDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}