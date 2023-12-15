using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IWarehouseRepository
    {
        WarehouseDbModel getRecordById(int id);
        IEnumerable<WarehouseDbModel> getRecordsList(string filter);
        WarehouseDbModel createRecord(WarehouseDbModel record);
        WarehouseDbModel updateRecord(WarehouseDbModel record);
        bool deleteRecordById(int id);
    }
}