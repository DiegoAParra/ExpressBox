using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class PersonImpApplication : IPersonApplication
    {
        IPersonRepository _repository;
        public PersonImpApplication(IPersonRepository repository)
        {
            this._repository = repository;
        }
        public PersonDTO createRecord(PersonDTO record)
        {
            PersonApplicationMapper mapper = new PersonApplicationMapper();
            PersonDbModel dbModel = mapper.DTOToDbModelMapper(record);
            PersonDbModel response = this._repository.createRecord(dbModel);
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

        public PersonDTO getRecordById(int id)
        {
            PersonApplicationMapper mapper = new PersonApplicationMapper();
            PersonDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<PersonDTO> getRecordList(string filter)
        {
            PersonApplicationMapper mapper = new PersonApplicationMapper();
            IEnumerable<PersonDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public PersonDTO updateRecord(PersonDTO record)
        {
            PersonApplicationMapper mapper = new PersonApplicationMapper();
            PersonDbModel dbModel = mapper.DTOToDbModelMapper(record);
            PersonDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}