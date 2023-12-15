using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Core
{
    public class PackageHistoryRepositoryMapper : DbModelMapperBase<PackageHistoryDbModel, Historial>
    {
        public override PackageHistoryDbModel DataBaseToDbModelMapper(Historial input)
        {
            return new PackageHistoryDbModel()
            {
                Id = input.Id,
                AdmissionDate = input.FechaIngreso,
                DepurateDate = input.FechaSalida,
                Description = input.Descripcion,
                Id_Package = input.Id_Paquete,
                Id_Warehouse = input.Id_Bodega,
                PackageName = input.Paquete != null ? input.Paquete.Id + "" : string.Empty,
                WarehouseName = input.Bodega != null ? input.Bodega.Nombre : string.Empty

            };
        }

        public override IEnumerable<PackageHistoryDbModel> DataBaseToDbModelMapper(IEnumerable<Historial> input)
        {
            IList<PackageHistoryDbModel> list = new List<PackageHistoryDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DataBaseToDbModelMapper(item));
            }
            return list;
        }

        public override Historial DbModelToDataBaseMapper(PackageHistoryDbModel input)
        {
            return new Historial()
            {
                Id = input.Id,
                FechaIngreso = input.AdmissionDate,
                FechaSalida = input.DepurateDate,
                Descripcion = input.Description,
                Id_Paquete = input.Id_Package,
                Id_Bodega = input.Id_Warehouse
            };
        }

        public override IEnumerable<Historial> DbModelToDataBaseMapper(IEnumerable<PackageHistoryDbModel> input)
        {
            IList<Historial> list = new List<Historial>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDataBaseMapper(item));
            }
            return list;
        }
    }
}
