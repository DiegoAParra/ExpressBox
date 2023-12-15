using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class WarehouseGUIMapper : ModelMapperBase<WarehouseModel, WarehouseDTO>
    {
        public override WarehouseModel DTOToModelMapper(WarehouseDTO input)
        {
            return new WarehouseModel()
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

        public override IEnumerable<WarehouseModel> DTOToModelMapper(IEnumerable<WarehouseDTO> input)
        {
            IList<WarehouseModel> list = new List<WarehouseModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override WarehouseDTO ModelToDTOMapper(WarehouseModel input)
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

        public override IEnumerable<WarehouseDTO> ModelToDTOMapper(IEnumerable<WarehouseModel> input)
        {
            IList<WarehouseDTO> list = new List<WarehouseDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }


    }

}