using PackageDelivery.Application.Contracts.DTO.Core;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Core
{
    public class DeliveryApplicationMapper : DTOMapperBase<DeliveryDTO, DeliveryDbModel>
    {
        public override DeliveryDTO DbModelToDTOMapper(DeliveryDbModel input)
        {
            return new DeliveryDTO()
            {
                Id = input.Id,
                DeliveryDate = input.DeliveryDate,
                Price = input.Price,
                Id_DestinationAddress = input.Id_DestinationAddress,
                Id_Package = input.Id_Package,
                Id_DeliveryStatus = input.Id_DeliveryStatus,
                Id_Sender = input.Id_Sender,
                Id_TransportType = input.Id_TransportType,
                DestinationAddressName = input.DestinationAddressName,
                PackageName = input.PackageName,
                DeliveryStatusName = input.DeliveryStatusName,
                SenderName = input.SenderName,
                TransportTypeName = input.TransportTypeName
            };
        }

        public override IEnumerable<DeliveryDTO> DbModelToDTOMapper(IEnumerable<DeliveryDbModel> input)
        {
            IList<DeliveryDTO> list = new List<DeliveryDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override DeliveryDbModel DTOToDbModelMapper(DeliveryDTO input)
        {
            return new DeliveryDbModel()
            {
                Id = input.Id,
                DeliveryDate = input.DeliveryDate,
                Price = input.Price,
                Id_DestinationAddress = input.Id_DestinationAddress,
                Id_Package = input.Id_Package,
                Id_DeliveryStatus = input.Id_DeliveryStatus,
                Id_Sender = input.Id_Sender,
                Id_TransportType = input.Id_TransportType
            };
        }

        public override IEnumerable<DeliveryDbModel> DTOToDbModelMapper(IEnumerable<DeliveryDTO> input)
        {
            IList<DeliveryDbModel> list = new List<DeliveryDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
