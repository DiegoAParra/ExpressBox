using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface ITransportTypeRepository
    {
        TransportTypeDbModel getRecordById(int id);
        IEnumerable<TransportTypeDbModel> getRecordsList(string filter);
        TransportTypeDbModel createRecord(TransportTypeDbModel record);
        TransportTypeDbModel updateRecord(TransportTypeDbModel record);
        bool deleteRecordById(int id);
    }
}