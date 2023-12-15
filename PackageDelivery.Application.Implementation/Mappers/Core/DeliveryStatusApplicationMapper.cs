using PackageDelivery.Application.Contracts.DTO.Core;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Core
{
    public class DeliveryStatusApplicationMapper : DTOMapperBase<DeliveryStatusDTO, DeliveryStatusDbModel>
    {
        public override DeliveryStatusDTO DbModelToDTOMapper(DeliveryStatusDbModel input)
        {
            return new DeliveryStatusDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<DeliveryStatusDTO> DbModelToDTOMapper(IEnumerable<DeliveryStatusDbModel> input)
        {
            IList<DeliveryStatusDTO> list = new List<DeliveryStatusDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override DeliveryStatusDbModel DTOToDbModelMapper(DeliveryStatusDTO input)
        {
            return new DeliveryStatusDbModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<DeliveryStatusDbModel> DTOToDbModelMapper(IEnumerable<DeliveryStatusDTO> input)
        {
            IList<DeliveryStatusDbModel> list = new List<DeliveryStatusDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
