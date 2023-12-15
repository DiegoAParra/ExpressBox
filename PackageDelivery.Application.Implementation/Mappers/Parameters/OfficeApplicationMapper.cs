using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class OfficeApplicationMapper : DTOMapperBase<OfficeDTO, OfficeDbModel>
    {
        public override OfficeDTO DbModelToDTOMapper(OfficeDbModel input)
        {
            return new OfficeDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Direction = input.Direction,
                Code = input.Code,
                CellPhone = input.CellPhone,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                Id_City = input.Id_City,
                CityName = input.CityName
            };
        }

        public override IEnumerable<OfficeDTO> DbModelToDTOMapper(IEnumerable<OfficeDbModel> input)
        {
            IList<OfficeDTO> list = new List<OfficeDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override OfficeDbModel DTOToDbModelMapper(OfficeDTO input)
        {
            return new OfficeDbModel()
            {
                Id = input.Id,
                Name = input.Name,
                Direction = input.Direction,
                Code = input.Code,
                CellPhone = input.CellPhone,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                Id_City = input.Id_City
            };
        }

        public override IEnumerable<OfficeDbModel> DTOToDbModelMapper(IEnumerable<OfficeDTO> input)
        {
            IList<OfficeDbModel> list = new List<OfficeDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}