using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Core
{
    public interface IPackageHistoryRepository
    {
        PackageHistoryDbModel getRecordById(int id);
        IEnumerable<PackageHistoryDbModel> getRecordsList(string filter);
        PackageHistoryDbModel createRecord(PackageHistoryDbModel record);
        PackageHistoryDbModel updateRecord(PackageHistoryDbModel record);
        bool deleteRecordById(int id);
    }
}