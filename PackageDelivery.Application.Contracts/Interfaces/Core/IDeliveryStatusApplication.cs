using PackageDelivery.Application.Contracts.DTO.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Core
{
    public interface IDeliveryStatusApplication
    {
        DeliveryStatusDTO getRecordById(int id);
        IEnumerable<DeliveryStatusDTO> getRecordList(string filter);
        DeliveryStatusDTO createRecord(DeliveryStatusDTO record);
        DeliveryStatusDTO updateRecord(DeliveryStatusDTO record);
        bool deleteRecordById(int id);
    }
}
