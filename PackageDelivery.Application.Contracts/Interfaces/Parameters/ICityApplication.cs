using PackageDelivery.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface ICityApplication
    {
        CityDTO getRecordById(int id);
        IEnumerable<CityDTO> getRecordList(string filter);
        CityDTO createRecord(CityDTO record);
        CityDTO updateRecord(CityDTO record);
        bool deleteRecordById(int id);
    }
}
