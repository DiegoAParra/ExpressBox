using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class AddressRepositoryMapper : DbModelMapperBase<AddressDbModel, Direccion>
    {
        public override AddressDbModel DataBaseToDbModelMapper(Direccion input)
        {
            return new AddressDbModel()
            {
                Id = input.Id,
                Current = input.Actual,
                StreetType = input.TipoCalle,
                Number = input.Numero,
                PropertyType = input.TipoInmueble,
                Neighborhood = input.Barrio,
                Observations = input.Observaciones,
                Id_Person = input.Id_Persona,
                Id_City = input.Id_Municipio,
                CityName = input.Municipio != null ? input.Municipio.Nombre : string.Empty,
                PersonName = input.Persona != null ? input.Persona.Documento : string.Empty
            };
        }

        public override IEnumerable<AddressDbModel> DataBaseToDbModelMapper(IEnumerable<Direccion> input)
        {
            IList<AddressDbModel> list = new List<AddressDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DataBaseToDbModelMapper(item));
            }
            return list;
        }

        public override Direccion DbModelToDataBaseMapper(AddressDbModel input)
        {
            return new Direccion()
            {
                Id = input.Id,
                Actual = input.Current,
                TipoCalle = input.StreetType,
                Numero = input.Number,
                TipoInmueble = input.PropertyType,
                Barrio = input.Neighborhood,
                Observaciones = input.Observations,
                Id_Persona = input.Id_Person,
                Id_Municipio = input.Id_City
            };
        }

        public override IEnumerable<Direccion> DbModelToDataBaseMapper(IEnumerable<AddressDbModel> input)
        {
            IList<Direccion> list = new List<Direccion>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDataBaseMapper(item));
            }
            return list;
        }
    }
}
