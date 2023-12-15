using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class CityGUIMapper : ModelMapperBase<CityModel, CityDTO>
    {
        public override CityModel DTOToModelMapper(CityDTO input)
        {
            return new CityModel()
            {
                Id = input.Id,
                Name = input.Name,
                Id_Department = input.Id_Department,
                DepartmentName = input.DepartmentName
            };
        }

        public override IEnumerable<CityModel> DTOToModelMapper(IEnumerable<CityDTO> input)
        {
            IList<CityModel> list = new List<CityModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override CityDTO ModelToDTOMapper(CityModel input)
        {
            return new CityDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Id_Department = input.Id_Department,
                DepartmentName = input.DepartmentName
            };
        }

        public override IEnumerable<CityDTO> ModelToDTOMapper(IEnumerable<CityModel> input)
        {
            IList<CityDTO> list = new List<CityDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }


    }

}