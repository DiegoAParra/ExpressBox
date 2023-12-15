using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface ICityRepository
    {
        CityDbModel getRecordById(int id);
        IEnumerable<CityDbModel> getRecordsList(string filter);
        CityDbModel createRecord(CityDbModel record);
        CityDbModel updateRecord(CityDbModel record);
        bool deleteRecordById(int id);
    }
}