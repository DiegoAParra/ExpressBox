using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class TransportTypeGUIMapper : ModelMapperBase<TransportTypeModel, TransportTypeDTO>
    {
        public override TransportTypeModel DTOToModelMapper(TransportTypeDTO input)
        {
            return new TransportTypeModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<TransportTypeModel> DTOToModelMapper(IEnumerable<TransportTypeDTO> input)
        {
            IList<TransportTypeModel> list = new List<TransportTypeModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override TransportTypeDTO ModelToDTOMapper(TransportTypeModel input)
        {
            return new TransportTypeDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<TransportTypeDTO> ModelToDTOMapper(IEnumerable<TransportTypeModel> input)
        {
            IList<TransportTypeDTO> list = new List<TransportTypeDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }


    }

}