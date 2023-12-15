using PackageDelivery.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IDepartmentApplication
    {
        DepartmentDTO getRecordById(int id);
        IEnumerable<DepartmentDTO> getRecordList(string filter);
        DepartmentDTO createRecord(DepartmentDTO record);
        DepartmentDTO updateRecord(DepartmentDTO record);
        bool deleteRecordById(int id);
    }
}
