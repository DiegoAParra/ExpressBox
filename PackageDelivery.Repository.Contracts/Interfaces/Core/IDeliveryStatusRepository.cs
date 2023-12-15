using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Core
{
    public interface IDeliveryStatusRepository
    {
        DeliveryStatusDbModel getRecordById(int id);
        IEnumerable<DeliveryStatusDbModel> getRecordsList(string filter);
        DeliveryStatusDbModel createRecord(DeliveryStatusDbModel record);
        DeliveryStatusDbModel updateRecord(DeliveryStatusDbModel record);
        bool deleteRecordById(int id);
    }
}