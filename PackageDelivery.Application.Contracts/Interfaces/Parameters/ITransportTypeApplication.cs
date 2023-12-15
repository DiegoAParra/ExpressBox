using PackageDelivery.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface ITransportTypeApplication
    {
        TransportTypeDTO getRecordById(int id);
        IEnumerable<TransportTypeDTO> getRecordList(string filter);
        TransportTypeDTO createRecord(TransportTypeDTO record);
        TransportTypeDTO updateRecord(TransportTypeDTO record);
        bool deleteRecordById(int id);
    }
}
