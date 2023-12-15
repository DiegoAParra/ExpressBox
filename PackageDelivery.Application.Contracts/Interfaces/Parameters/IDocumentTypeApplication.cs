using PackageDelivery.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IDocumentTypeApplication
    {
        DocumentTypeDTO getRecordById(int id);
        IEnumerable<DocumentTypeDTO> getRecordList(string filter);
        DocumentTypeDTO createRecord(DocumentTypeDTO record);
        DocumentTypeDTO updateRecord(DocumentTypeDTO record);
        bool deleteRecordById(int id);
    }
}
