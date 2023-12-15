using PackageDelivery.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IPersonApplication
    {
        PersonDTO getRecordById(int id);
        IEnumerable<PersonDTO> getRecordList(string filter);
        PersonDTO createRecord(PersonDTO record);
        PersonDTO updateRecord(PersonDTO record);
        bool deleteRecordById(int id);
    }
}