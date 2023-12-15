using PackageDelivery.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IPackageApplication
    {
        PackageDTO getRecordById(int id);
        IEnumerable<PackageDTO> getRecordList(string filter);
        PackageDTO createRecord(PackageDTO record);
        PackageDTO updateRecord(PackageDTO record);
        bool deleteRecordById(int id);
    }
}
