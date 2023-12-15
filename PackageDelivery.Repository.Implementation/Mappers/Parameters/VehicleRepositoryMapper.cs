using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class VehicleRepositoryMapper : DbModelMapperBase<VehicleDbModel, vehiculo>
    {
        public override VehicleDbModel DataBaseToDbModelMapper(vehiculo input)
        {
            return new VehicleDbModel()
            {
                Id = input.id,
                Plate = input.placa,
                IdTransportType = (long)input.idTipoTransporte,
                TransportTypeName = input.TipoTransporte != null ? input.TipoTransporte.nombre : string.Empty
            };
        }

        public override IEnumerable<VehicleDbModel> DataBaseToDbModelMapper(IEnumerable<vehiculo> input)
        {
            IList<VehicleDbModel> list = new List<VehicleDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DataBaseToDbModelMapper(item));
            }
            return list;
        }

        public override vehiculo DbModelToDataBaseMapper(VehicleDbModel input)
        {
            return new vehiculo()
            {
                id = input.Id,
                placa = input.Plate,
                idTipoTransporte = input.IdTransportType
            };
        }

        public override IEnumerable<vehiculo> DbModelToDataBaseMapper(IEnumerable<VehicleDbModel> input)
        {
            IList<vehiculo> list = new List<vehiculo>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDataBaseMapper(item));
            }
            return list;
        }
    }
}
