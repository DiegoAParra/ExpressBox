using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Core
{
    public class DeliveryStatusRepositoryMapper : DbModelMapperBase<DeliveryStatusDbModel, EstadoEnvio>
    {
        public override DeliveryStatusDbModel DataBaseToDbModelMapper(EstadoEnvio input)
        {
            return new DeliveryStatusDbModel()
            {
                Id = input.Id,
                Name = input.Nombre
            };
        }

        public override IEnumerable<DeliveryStatusDbModel> DataBaseToDbModelMapper(IEnumerable<EstadoEnvio> input)
        {
            IList<DeliveryStatusDbModel> list = new List<DeliveryStatusDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DataBaseToDbModelMapper(item));
            }
            return list;
        }

        public override EstadoEnvio DbModelToDataBaseMapper(DeliveryStatusDbModel input)
        {
            return new EstadoEnvio()
            {
                Id = input.Id,
                Nombre = input.Name
            };
        }

        public override IEnumerable<EstadoEnvio> DbModelToDataBaseMapper(IEnumerable<DeliveryStatusDbModel> input)
        {
            IList<EstadoEnvio> list = new List<EstadoEnvio>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDataBaseMapper(item));
            }
            return list;
        }
    }
}
