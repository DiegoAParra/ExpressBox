using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class PackageImpApplication : IPackageApplication
    {
        IPackageRepository _repository;
        public PackageImpApplication(IPackageRepository repository)
        {
            this._repository = repository;
        }
        public PackageDTO createRecord(PackageDTO record)
        {
            PackageApplicationMapper mapper = new PackageApplicationMapper();
            PackageDbModel dbModel = mapper.DTOToDbModelMapper(record);
            PackageDbModel response = this._repository.createRecord(dbModel);
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

        public PackageDTO getRecordById(int id)
        {
            PackageApplicationMapper mapper = new PackageApplicationMapper();
            PackageDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<PackageDTO> getRecordList(string filter)
        {
            PackageApplicationMapper mapper = new PackageApplicationMapper();
            IEnumerable<PackageDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public PackageDTO updateRecord(PackageDTO record)
        {
            PackageApplicationMapper mapper = new PackageApplicationMapper();
            PackageDbModel dbModel = mapper.DTOToDbModelMapper(record);
            PackageDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}