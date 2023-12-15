using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class WarehouseRepositoryMapper : DbModelMapperBase<WarehouseDbModel, Bodega>
    {
        public override WarehouseDbModel DataBaseToDbModelMapper(Bodega input)
        {
            return new WarehouseDbModel()
            {
                Id = input.Id,
                Name = input.Nombre,
                Direction = input.Direccion,
                Code = input.Codigo,
                Latitude = input.latitud,
                Longitude = input.longitud,
                Id_City = input.Id_Municipio,
                CityName = input.Municipio != null ? input.Municipio.Nombre:string.Empty
            };
        }

        public override IEnumerable<WarehouseDbModel> DataBaseToDbModelMapper(IEnumerable<Bodega> input)
        {
            IList<WarehouseDbModel> list = new List<WarehouseDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DataBaseToDbModelMapper(item));
            }
            return list;
        }

        public override Bodega DbModelToDataBaseMapper(WarehouseDbModel input)
        {
            return new Bodega()
            {
                Id = input.Id,
                Nombre = input.Name,
                Direccion = input.Direction,
                Codigo = input.Code,
                latitud = input.Latitude,
                longitud  = input.Longitude,
                Id_Municipio = input.Id_City
            };
        }

        public override IEnumerable<Bodega> DbModelToDataBaseMapper(IEnumerable<WarehouseDbModel> input)
        {
            IList<Bodega> list = new List<Bodega>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDataBaseMapper(item));
            }
            return list;
        }
    }
}
