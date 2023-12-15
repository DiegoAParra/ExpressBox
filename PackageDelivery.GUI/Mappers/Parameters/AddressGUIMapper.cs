using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class AddressGUIMapper : ModelMapperBase<AddressModel, AddressDTO>
    {
        public override AddressModel DTOToModelMapper(AddressDTO input)
        {
            return new AddressModel()
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
                PersonName = input.PersonName,
                CityName = input.CityName
            };
        }

        public override IEnumerable<AddressModel> DTOToModelMapper(IEnumerable<AddressDTO> input)
        {
            IList<AddressModel> list = new List<AddressModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override AddressDTO ModelToDTOMapper(AddressModel input)
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
                Id_City = input.Id_City
            };
        }

        public override IEnumerable<AddressDTO> ModelToDTOMapper(IEnumerable<AddressModel> input)
        {
            IList<AddressDTO> list = new List<AddressDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }


    }

}