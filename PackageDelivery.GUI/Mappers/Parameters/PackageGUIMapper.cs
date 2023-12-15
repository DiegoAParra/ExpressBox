using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class PackageGUIMapper : ModelMapperBase<PackageModel, PackageDTO>
    {
        public override PackageModel DTOToModelMapper(PackageDTO input)
        {
            return new PackageModel()
            {
                Id = input.Id,
                Weight = input.Weight,
                Depth = input.Depth,
                Width = input.Width,
                Height = input.Height,
                Id_Office = input.Id_Office,
                OfficeName = input.OfficeName
            };
        }

        public override IEnumerable<PackageModel> DTOToModelMapper(IEnumerable<PackageDTO> input)
        {
            IList<PackageModel> list = new List<PackageModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override PackageDTO ModelToDTOMapper(PackageModel input)
        {
            return new PackageDTO()
            {
                Id = input.Id,
                Weight = input.Weight,
                Depth = input.Depth,
                Width = input.Width,
                Height = input.Height,
                Id_Office = input.Id_Office,
                OfficeName = input.OfficeName
            };
        }

        public override IEnumerable<PackageDTO> ModelToDTOMapper(IEnumerable<PackageModel> input)
        {
            IList<PackageDTO> list = new List<PackageDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }


    }

}