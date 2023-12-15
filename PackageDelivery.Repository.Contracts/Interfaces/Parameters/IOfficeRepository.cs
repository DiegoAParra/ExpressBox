using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IOfficeRepository
    {
        OfficeDbModel getRecordById(int id);
        IEnumerable<OfficeDbModel> getRecordsList(string filter);
        OfficeDbModel createRecord(OfficeDbModel record);
        OfficeDbModel updateRecord(OfficeDbModel record);
        bool deleteRecordById(int id);
    }
}