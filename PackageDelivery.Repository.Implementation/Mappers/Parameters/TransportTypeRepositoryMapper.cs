using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class TransportTypeRepositoryMapper : DbModelMapperBase<TransportTypeDbModel, TipoTransporte>
    {
        public override TransportTypeDbModel DataBaseToDbModelMapper(TipoTransporte input)
        {
            return new TransportTypeDbModel()
            {
                Id = input.Id,
                Name = input.nombre
            };
        }

        public override IEnumerable<TransportTypeDbModel> DataBaseToDbModelMapper(IEnumerable<TipoTransporte> input)
        {
            IList<TransportTypeDbModel> list = new List<TransportTypeDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DataBaseToDbModelMapper(item));
            }
            return list;
        }

        public override TipoTransporte DbModelToDataBaseMapper(TransportTypeDbModel input)
        {
            return new TipoTransporte()
            {
                Id = input.Id,
                nombre = input.Name
            };
        }

        public override IEnumerable<TipoTransporte> DbModelToDataBaseMapper(IEnumerable<TransportTypeDbModel> input)
        {
            IList<TipoTransporte> list = new List<TipoTransporte>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDataBaseMapper(item));
            }
            return list;
        }
    }
}
