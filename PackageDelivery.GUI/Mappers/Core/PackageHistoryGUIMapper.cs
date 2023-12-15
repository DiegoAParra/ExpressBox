using PackageDelivery.Application.Contracts.DTO.Core;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;

namespace PackagePackageHistory.GUI.Mappers.Core
{
    public class PackageHistoryGUIMapper : ModelMapperBase<PackageHistoryModel, PackageHistoryDTO>
    {
        public override PackageHistoryModel DTOToModelMapper(PackageHistoryDTO input)
        {
            return new PackageHistoryModel()
            {
                Id = input.Id,
                AdmissionDate = input.AdmissionDate,
                DepurateDate = input.DepurateDate,
                Description = input.Description,
                Id_Package = input.Id_Package,
                Id_Warehouse = input.Id_Warehouse,
                PackageName = input.PackageName,
                WarehouseName = input.WarehouseName
            };
        }

        public override IEnumerable<PackageHistoryModel> DTOToModelMapper(IEnumerable<PackageHistoryDTO> input)
        {
            IList<PackageHistoryModel> list = new List<PackageHistoryModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override PackageHistoryDTO ModelToDTOMapper(PackageHistoryModel input)
        {
            return new PackageHistoryDTO()
            {
                Id = input.Id,
                AdmissionDate = input.AdmissionDate,
                DepurateDate = input.DepurateDate,
                Description = input.Description,
                Id_Package = input.Id_Package,
                Id_Warehouse = input.Id_Warehouse
            };
        }

        public override IEnumerable<PackageHistoryDTO> ModelToDTOMapper(IEnumerable<PackageHistoryModel> input)
        {
            IList<PackageHistoryDTO> list = new List<PackageHistoryDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }


    }

}