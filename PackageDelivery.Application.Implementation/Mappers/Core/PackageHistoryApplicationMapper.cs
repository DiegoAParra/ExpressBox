
using PackageDelivery.Application.Contracts.DTO.Core;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Core
{
    public class PackageHistoryApplicationMapper : DTOMapperBase<PackageHistoryDTO, PackageHistoryDbModel>
    {
        public override PackageHistoryDTO DbModelToDTOMapper(PackageHistoryDbModel input)
        {
            return new PackageHistoryDTO()
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

        public override IEnumerable<PackageHistoryDTO> DbModelToDTOMapper(IEnumerable<PackageHistoryDbModel> input)
        {
            IList<PackageHistoryDTO> list = new List<PackageHistoryDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override PackageHistoryDbModel DTOToDbModelMapper(PackageHistoryDTO input)
        {
            return new PackageHistoryDbModel()
            {
                Id = input.Id,
                AdmissionDate = input.AdmissionDate,
                DepurateDate = input.DepurateDate,
                Description = input.Description,
                Id_Package = input.Id_Package,
                Id_Warehouse = input.Id_Warehouse
            };
        }

        public override IEnumerable<PackageHistoryDbModel> DTOToDbModelMapper(IEnumerable<PackageHistoryDTO> input)
        {
            IList<PackageHistoryDbModel> list = new List<PackageHistoryDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
