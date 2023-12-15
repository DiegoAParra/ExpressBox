using PackageDelivery.Application.Contracts.DTO.Core;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Core
{
    public class DeliveryGUIMapper : ModelMapperBase<DeliveryModel, DeliveryDTO>
    {
        public override DeliveryModel DTOToModelMapper(DeliveryDTO input)
        {
            return new DeliveryModel()
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

        public override IEnumerable<DeliveryModel> DTOToModelMapper(IEnumerable<DeliveryDTO> input)
        {
            IList<DeliveryModel> list = new List<DeliveryModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override DeliveryDTO ModelToDTOMapper(DeliveryModel input)
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
                Id_TransportType = input.Id_TransportType
            };
        }

        public override IEnumerable<DeliveryDTO> ModelToDTOMapper(IEnumerable<DeliveryModel> input)
        {
            IList<DeliveryDTO> list = new List<DeliveryDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }


    }

}