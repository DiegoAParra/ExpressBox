using PackageDelivery.Application.Contracts.DTO.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IDeliveryApplication
    {
        DeliveryDTO getRecordById(int id);
        IEnumerable<DeliveryDTO> getRecordList(string filter);
        DeliveryDTO createRecord(DeliveryDTO record);
        DeliveryDTO updateRecord(DeliveryDTO record);
        bool deleteRecordById(int id);
    }
}
