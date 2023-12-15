using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class DepartmentRepositoryMapper : DbModelMapperBase<DepartmentDbModel, Departamento>
    {
        public override DepartmentDbModel DataBaseToDbModelMapper(Departamento input)
        {
            return new DepartmentDbModel()
            {
                Id = input.Id,
                Name = input.Nombre
            };
        }

        public override IEnumerable<DepartmentDbModel> DataBaseToDbModelMapper(IEnumerable<Departamento> input)
        {
            IList<DepartmentDbModel> list = new List<DepartmentDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DataBaseToDbModelMapper(item));
            }
            return list;
        }

        public override Departamento DbModelToDataBaseMapper(DepartmentDbModel input)
        {
            return new Departamento()
            {
                Id = input.Id,
                Nombre = input.Name
            };
        }

        public override IEnumerable<Departamento> DbModelToDataBaseMapper(IEnumerable<DepartmentDbModel> input)
        {
            IList<Departamento> list = new List<Departamento>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDataBaseMapper(item));
            }
            return list;
        }
    }
}
