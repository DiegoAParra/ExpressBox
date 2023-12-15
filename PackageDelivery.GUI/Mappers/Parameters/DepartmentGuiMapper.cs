using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class DepartmentGUIMapper : ModelMapperBase<DepartmentModel, DepartmentDTO>
    {
        public override DepartmentModel DTOToModelMapper(DepartmentDTO input)
        {
            return new DepartmentModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<DepartmentModel> DTOToModelMapper(IEnumerable<DepartmentDTO> input)
        {
            IList<DepartmentModel> list = new List<DepartmentModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override DepartmentDTO ModelToDTOMapper(DepartmentModel input)
        {
            return new DepartmentDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<DepartmentDTO> ModelToDTOMapper(IEnumerable<DepartmentModel> input)
        {
            IList<DepartmentDTO> list = new List<DepartmentDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }


    }

}
