using PackageDelivery.Application.Contracts.DTO.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Core
{
    public interface IPackageHistoryApplication
    {
        PackageHistoryDTO getRecordById(int id);
        IEnumerable<PackageHistoryDTO> getRecordList(string filter);
        PackageHistoryDTO createRecord(PackageHistoryDTO record);
        PackageHistoryDTO updateRecord(PackageHistoryDTO record);
        bool deleteRecordById(int id);
    }
}
