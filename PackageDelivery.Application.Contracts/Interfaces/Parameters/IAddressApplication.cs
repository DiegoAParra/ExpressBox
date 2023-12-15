using PackageDelivery.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IAddressApplication
    {
        AddressDTO getRecordById(int id);
        IEnumerable<AddressDTO> getRecordList(string filter);
        AddressDTO createRecord(AddressDTO record);
        AddressDTO updateRecord(AddressDTO record);
        bool deleteRecordById(int id);
    }
}