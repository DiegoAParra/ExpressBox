using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class OfficeRepositoryMapper : DbModelMapperBase<OfficeDbModel, Oficina>
    {
        public override OfficeDbModel DataBaseToDbModelMapper(Oficina input)
        {
            return new OfficeDbModel()
            {
                Id = input.Id,
                Name = input.Nombre,
                Direction = input.Direccion,
                Code = input.Codigo,
                CellPhone = input.Telefono,
                Latitude = input.Latitud,
                Longitude = input.Longitud,
                Id_City = input.Id_Municipio,
                CityName = input.Municipio != null ? input.Municipio.Nombre : string.Empty
            };
        }

        public override IEnumerable<OfficeDbModel> DataBaseToDbModelMapper(IEnumerable<Oficina> input)
        {
            IList<OfficeDbModel> list = new List<OfficeDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DataBaseToDbModelMapper(item));
            }
            return list;
        }

        public override Oficina DbModelToDataBaseMapper(OfficeDbModel input)
        {
            return new Oficina()
            {
                Id = input.Id,
                Nombre = input.Name,
                Direccion = input.Direction,
                Codigo = input.Code,
                Telefono = input.CellPhone,
                Latitud = input.Latitude,
                Longitud = input.Longitude,
                Id_Municipio = input.Id_City
            };
        }

        public override IEnumerable<Oficina> DbModelToDataBaseMapper(IEnumerable<OfficeDbModel> input)
        {
            IList<Oficina> list = new List<Oficina>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDataBaseMapper(item));
            }
            return list;
        }
    }
}
