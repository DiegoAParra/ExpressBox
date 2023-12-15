using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class AddressImpApplication : IAddressApplication
    {
        IAddressRepository _repository;
        public AddressImpApplication(IAddressRepository repository)
        {
            this._repository = repository;
        }
        public AddressDTO createRecord(AddressDTO record)
        {
            AddressApplicationMapper mapper = new AddressApplicationMapper();
            AddressDbModel dbModel = mapper.DTOToDbModelMapper(record);
            AddressDbModel response = this._repository.createRecord(dbModel);
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

        public AddressDTO getRecordById(int id)
        {
            AddressApplicationMapper mapper = new AddressApplicationMapper();
            AddressDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<AddressDTO> getRecordList(string filter)
        {
            AddressApplicationMapper mapper = new AddressApplicationMapper();
            IEnumerable<AddressDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public AddressDTO updateRecord(AddressDTO record)
        {
            AddressApplicationMapper mapper = new AddressApplicationMapper();
            AddressDbModel dbModel = mapper.DTOToDbModelMapper(record);
            AddressDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}