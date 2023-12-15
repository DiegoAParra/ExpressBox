using PackageDelivery.Application.Contracts.DTO.Core;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Mappers.Core;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
    public class PackageHistoryImpApplication : IPackageHistoryApplication
    {
        IPackageHistoryRepository _repository;
        public PackageHistoryImpApplication(IPackageHistoryRepository repository)
        {
            this._repository = repository;
        }
        public PackageHistoryDTO createRecord(PackageHistoryDTO record)
        {
            PackageHistoryApplicationMapper mapper = new PackageHistoryApplicationMapper();
            PackageHistoryDbModel dbModel = mapper.DTOToDbModelMapper(record);
            PackageHistoryDbModel response = this._repository.createRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }

        public bool deleteRecordById(int id)
        {
            return _repository.deleteRecordById(id);
        }

        public PackageHistoryDTO getRecordById(int id)
        {
            PackageHistoryApplicationMapper mapper = new PackageHistoryApplicationMapper();
            PackageHistoryDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<PackageHistoryDTO> getRecordList(string filter)
        {
            PackageHistoryApplicationMapper mapper = new PackageHistoryApplicationMapper();
            IEnumerable<PackageHistoryDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public PackageHistoryDTO updateRecord(PackageHistoryDTO record)
        {
            PackageHistoryApplicationMapper mapper = new PackageHistoryApplicationMapper();
            PackageHistoryDbModel dbModel = mapper.DTOToDbModelMapper(record);
            PackageHistoryDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}