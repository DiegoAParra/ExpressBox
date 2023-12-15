using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers
{
    public abstract class DbModelMapperBase<DbModelType,DataBaseType>
    {
        public abstract DataBaseType DbModelToDataBaseMapper(DbModelType input);
        public abstract DbModelType DataBaseToDbModelMapper(DataBaseType input);
        public abstract IEnumerable<DataBaseType> DbModelToDataBaseMapper(IEnumerable<DbModelType> input);
        public abstract IEnumerable<DbModelType> DataBaseToDbModelMapper(IEnumerable<DataBaseType> input);
    }
}
