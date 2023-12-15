using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class DocumentTypeRepositoryMapper : DbModelMapperBase<DocumentTypeDbModel, TipoDocumento>
    {
        public override DocumentTypeDbModel DataBaseToDbModelMapper(TipoDocumento input)
        {
            return new DocumentTypeDbModel()
            {
                Id = input.Id,
                Name = input.Nombre.Trim()
            };
        }

        public override IEnumerable<DocumentTypeDbModel> DataBaseToDbModelMapper(IEnumerable<TipoDocumento> input)
        {
            IList<DocumentTypeDbModel> list = new List<DocumentTypeDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DataBaseToDbModelMapper(item));
            }
            return list;
        }

        public override TipoDocumento DbModelToDataBaseMapper(DocumentTypeDbModel input)
        {
            return new TipoDocumento()
            {
                Id = input.Id,
                Nombre = input.Name
            };
        }

        public override IEnumerable<TipoDocumento> DbModelToDataBaseMapper(IEnumerable<DocumentTypeDbModel> input)
        {
            IList<TipoDocumento> list = new List<TipoDocumento>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDataBaseMapper(item));
            }
            return list;
        }
    }
}
