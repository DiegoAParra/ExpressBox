
using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class VehicleApplicationMapper : DTOMapperBase<VehicleDTO, VehicleDbModel>
    {
        public override VehicleDTO DbModelToDTOMapper(VehicleDbModel input)
        {
            return new VehicleDTO()
            {
                Id = input.Id,
                Plate = input.Plate,
                IdTransportType = (long)input.IdTransportType,
                TransportTypeName = input.TransportTypeName
            };
        }

        public override IEnumerable<VehicleDTO> DbModelToDTOMapper(IEnumerable<VehicleDbModel> input)
        {
            IList<VehicleDTO> list = new List<VehicleDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override VehicleDbModel DTOToDbModelMapper(VehicleDTO input)
        {
            return new VehicleDbModel()
            {
                Id = input.Id,
                Plate = input.Plate,
                IdTransportType = (long)input.IdTransportType
            };
        }

        public override IEnumerable<VehicleDbModel> DTOToDbModelMapper(IEnumerable<VehicleDTO> input)
        {
            IList<VehicleDbModel> list = new List<VehicleDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
