using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class CityImpApplication : ICityApplication
    {
        private ICityRepository _repository;
        public CityImpApplication(ICityRepository repository) 
        {
            this._repository = repository;
        }
        
        public CityDTO createRecord(CityDTO record)
        {
            CityApplicationMapper mapper = new CityApplicationMapper();
            CityDbModel dbModel = mapper.DTOToDbModelMapper(record);
            CityDbModel response = this._repository.createRecord(dbModel);
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

        public CityDTO getRecordById(int id)
        {
            CityApplicationMapper mapper = new CityApplicationMapper();
            CityDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<CityDTO> getRecordList(string filter)
        {
            CityApplicationMapper mapper = new CityApplicationMapper();
            IEnumerable<CityDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public CityDTO updateRecord(CityDTO record)
        {
            CityApplicationMapper mapper = new CityApplicationMapper();
            CityDbModel dbModel = mapper.DTOToDbModelMapper(record);
            CityDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}