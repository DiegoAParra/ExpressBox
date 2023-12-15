using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IPersonRepository
    {
        PersonDbModel getRecordById(int id);
        IEnumerable<PersonDbModel> getRecordsList(string filter);
        PersonDbModel createRecord(PersonDbModel record);
        PersonDbModel updateRecord(PersonDbModel record);
        bool deleteRecordById(int id);
    }
}