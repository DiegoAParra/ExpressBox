using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IAddressRepository
    {
        AddressDbModel getRecordById(int id);
        IEnumerable<AddressDbModel> getRecordsList(string filter);
        AddressDbModel createRecord(AddressDbModel record);
        AddressDbModel updateRecord(AddressDbModel record);
        bool deleteRecordById(int id);
    }
}