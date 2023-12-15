using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IDeliveryRepository
    {
        DeliveryDbModel getRecordById(int id);
        IEnumerable<DeliveryDbModel> getRecordsList(string filter);
        DeliveryDbModel createRecord(DeliveryDbModel record);
        DeliveryDbModel updateRecord(DeliveryDbModel record);
        bool deleteRecordById(int id);
    }
}