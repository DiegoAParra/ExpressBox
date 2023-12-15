using PackageDelivery.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IVehicleApplication
    {
        VehicleDTO getRecordById(int id);
        IEnumerable<VehicleDTO> getRecordList(string filter);
        VehicleDTO createRecord(VehicleDTO record);
        VehicleDTO updateRecord(VehicleDTO record);
        bool deleteRecordById(int id);
    }
}
