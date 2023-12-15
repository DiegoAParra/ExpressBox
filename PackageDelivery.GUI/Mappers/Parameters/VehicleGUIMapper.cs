using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class VehicleGUIMapper : ModelMapperBase<VehicleModel, VehicleDTO>
    {
        public override VehicleModel DTOToModelMapper(VehicleDTO input)
        {
            return new VehicleModel()
            {
                Id = input.Id,
                Plate = input.Plate,
                IdTransportType = (long)input.IdTransportType,
                TransportTypeName = input.TransportTypeName
            };
        }

        public override IEnumerable<VehicleModel> DTOToModelMapper(IEnumerable<VehicleDTO> input)
        {
            IList<VehicleModel> list = new List<VehicleModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override VehicleDTO ModelToDTOMapper(VehicleModel input)
        {
            return new VehicleDTO()
            {
                Id = input.Id,
                Plate = input.Plate,
                IdTransportType = (long)input.IdTransportType
            };
        }

        public override IEnumerable<VehicleDTO> ModelToDTOMapper(IEnumerable<VehicleModel> input)
        {
            IList<VehicleDTO> list = new List<VehicleDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }


    }

}