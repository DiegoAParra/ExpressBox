using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class PackageRepositoryMapper : DbModelMapperBase<PackageDbModel, Paquete>
    {
        public override PackageDbModel DataBaseToDbModelMapper(Paquete input)
        {
            return new PackageDbModel()
            {
                Id = input.Id,
                Weight = input.Peso,
                Depth = input.Profundidad,
                Width = input.Ancho,
                Height = input.Altura,
                Id_Office = input.Id_Oficina,
                OfficeName = input.Oficina != null ? input.Oficina.Nombre : string.Empty
            };
        }

        public override IEnumerable<PackageDbModel> DataBaseToDbModelMapper(IEnumerable<Paquete> input)
        {
            IList<PackageDbModel> list = new List<PackageDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DataBaseToDbModelMapper(item));
            }
            return list;
        }

        public override Paquete DbModelToDataBaseMapper(PackageDbModel input)
        {
            return new Paquete()
            {
                Id = input.Id,
                Peso = input.Weight,
                Profundidad = input.Depth,
                Ancho = input.Width,
                Altura = input.Height,
                Id_Oficina = input.Id_Office
            };
        }

        public override IEnumerable<Paquete> DbModelToDataBaseMapper(IEnumerable<PackageDbModel> input)
        {
            IList<Paquete> list = new List<Paquete>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDataBaseMapper(item));
            }
            return list;
        }
    }
}
