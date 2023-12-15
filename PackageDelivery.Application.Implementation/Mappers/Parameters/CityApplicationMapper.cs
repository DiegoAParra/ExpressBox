using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class CityApplicationMapper : DTOMapperBase<CityDTO, CityDbModel>
    {
        public override CityDTO DbModelToDTOMapper(CityDbModel input)
        {
            return new CityDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Id_Department = input.Id_Department,
                DepartmentName = input.DepartmentName
            };
        }

        public override IEnumerable<CityDTO> DbModelToDTOMapper(IEnumerable<CityDbModel> input)
        {
            IList<CityDTO> list = new List<CityDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override CityDbModel DTOToDbModelMapper(CityDTO input)
        {
            return new CityDbModel()
            {
                Id = input.Id,
                Name = input.Name,
                Id_Department = input.Id_Department,
                DepartmentName = input.DepartmentName
            };
        }

        public override IEnumerable<CityDbModel> DTOToDbModelMapper(IEnumerable<CityDTO> input)
        {
            IList<CityDbModel> list = new List<CityDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
