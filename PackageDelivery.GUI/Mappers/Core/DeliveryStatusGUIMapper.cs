using PackageDelivery.Application.Contracts.DTO.Core;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Core
{
    public class DeliveryStatusGUIMapper : ModelMapperBase<DeliveryStatusModel, DeliveryStatusDTO>
    {
        public override DeliveryStatusModel DTOToModelMapper(DeliveryStatusDTO input)
        {
            return new DeliveryStatusModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<DeliveryStatusModel> DTOToModelMapper(IEnumerable<DeliveryStatusDTO> input)
        {
            IList<DeliveryStatusModel> list = new List<DeliveryStatusModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override DeliveryStatusDTO ModelToDTOMapper(DeliveryStatusModel input)
        {
            return new DeliveryStatusDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<DeliveryStatusDTO> ModelToDTOMapper(IEnumerable<DeliveryStatusModel> input)
        {
            IList<DeliveryStatusDTO> list = new List<DeliveryStatusDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }


    }

}