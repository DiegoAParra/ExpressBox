using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class CityRepositoryMapper : DbModelMapperBase<CityDbModel, Municipio>
    {
        public override CityDbModel DataBaseToDbModelMapper(Municipio input)
        {
            return new CityDbModel()
            {
                Id = input.Id,
                Name = input.Nombre,
                Id_Department = input.Id_Depto,
                DepartmentName = input.Departamento != null ? input.Departamento.Nombre : string.Empty
            };
        }

        public override IEnumerable<CityDbModel> DataBaseToDbModelMapper(IEnumerable<Municipio> input)
        {
            IList<CityDbModel> list = new List<CityDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DataBaseToDbModelMapper(item));
            }
            return list;
        }

        public override Municipio DbModelToDataBaseMapper(CityDbModel input)
        {
            return new Municipio()
            {
                Id = input.Id,
                Nombre = input.Name,
                Id_Depto= input.Id_Department
            };
        }

        public override IEnumerable<Municipio> DbModelToDataBaseMapper(IEnumerable<CityDbModel> input)
        {
            IList<Municipio> list = new List<Municipio>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDataBaseMapper(item));
            }
            return list;
        }
    }
}
