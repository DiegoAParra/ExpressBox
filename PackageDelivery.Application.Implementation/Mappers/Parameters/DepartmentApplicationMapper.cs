
using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class DepartmentApplicationMapper : DTOMapperBase<DepartmentDTO, DepartmentDbModel>
    {
        public override DepartmentDTO DbModelToDTOMapper(DepartmentDbModel input)
        {
            return new DepartmentDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<DepartmentDTO> DbModelToDTOMapper(IEnumerable<DepartmentDbModel> input)
        {
            IList<DepartmentDTO> list = new List<DepartmentDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override DepartmentDbModel DTOToDbModelMapper(DepartmentDTO input)
        {
            return new DepartmentDbModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<DepartmentDbModel> DTOToDbModelMapper(IEnumerable<DepartmentDTO> input)
        {
            IList<DepartmentDbModel> list = new List<DepartmentDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
