using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class WarehouseApplicationMapper : DTOMapperBase<WarehouseDTO, WarehouseDbModel>
    {
        public override WarehouseDTO DbModelToDTOMapper(WarehouseDbModel input)
        {
            return new WarehouseDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Direction = input.Direction,
                Code = input.Code,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                Id_City = input.Id_City,
                CityName = input.CityName
            };
        }

        public override IEnumerable<WarehouseDTO> DbModelToDTOMapper(IEnumerable<WarehouseDbModel> input)
        {
            IList<WarehouseDTO> list = new List<WarehouseDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override WarehouseDbModel DTOToDbModelMapper(WarehouseDTO input)
        {
            return new WarehouseDbModel()
            {
                Id = input.Id,
                Name = input.Name,
                Direction = input.Direction,
                Code = input.Code,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                Id_City = input.Id_City
            };
        }

        public override IEnumerable<WarehouseDbModel> DTOToDbModelMapper(IEnumerable<WarehouseDTO> input)
        {
            IList<WarehouseDbModel> list = new List<WarehouseDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}