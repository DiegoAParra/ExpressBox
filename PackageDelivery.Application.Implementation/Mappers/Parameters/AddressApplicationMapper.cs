using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class AddressApplicationMapper : DTOMapperBase<AddressDTO, AddressDbModel>
    {
        public override AddressDTO DbModelToDTOMapper(AddressDbModel input)
        {
            return new AddressDTO()
            {
                Id = input.Id,
                Current = input.Current,
                StreetType = input.StreetType,
                Number = input.Number,
                PropertyType = input.PropertyType,
                Neighborhood = input.Neighborhood,
                Observations = input.Observations,
                Id_Person = input.Id_Person,
                Id_City = input.Id_City,
                CityName = input.CityName,
                PersonName = input.PersonName
            };
        }

        public override IEnumerable<AddressDTO> DbModelToDTOMapper(IEnumerable<AddressDbModel> input)
        {
            IList<AddressDTO> list = new List<AddressDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override AddressDbModel DTOToDbModelMapper(AddressDTO input)
        {
            return new AddressDbModel()
            {
                Id = input.Id,
                Current = input.Current,
                StreetType = input.StreetType,
                Number = input.Number,
                PropertyType = input.PropertyType,
                Neighborhood = input.Neighborhood,
                Observations = input.Observations,
                Id_Person = input.Id_Person,
                Id_City = input.Id_City
            };
        }

        public override IEnumerable<AddressDbModel> DTOToDbModelMapper(IEnumerable<AddressDTO> input)
        {
            IList<AddressDbModel> list = new List<AddressDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
