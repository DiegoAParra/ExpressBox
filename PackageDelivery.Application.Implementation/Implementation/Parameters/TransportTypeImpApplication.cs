using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class TransportTypeImpApplication : ITransportTypeApplication
    {
        ITransportTypeRepository _repository;
        public TransportTypeImpApplication(ITransportTypeRepository repository)
        {
            this._repository = repository;
        }
        public TransportTypeDTO createRecord(TransportTypeDTO record)
        {
            TransportTypeApplicationMapper mapper = new TransportTypeApplicationMapper();
            TransportTypeDbModel dbModel = mapper.DTOToDbModelMapper(record);
            TransportTypeDbModel response = this._repository.createRecord(dbModel);
            if(response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }

        public bool deleteRecordById(int id)
        {
            return _repository.deleteRecordById(id);
        }

        public TransportTypeDTO getRecordById(int id)
        {
            TransportTypeApplicationMapper mapper = new TransportTypeApplicationMapper();
            TransportTypeDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<TransportTypeDTO> getRecordList(string filter)
        {
            TransportTypeApplicationMapper mapper = new TransportTypeApplicationMapper();
            IEnumerable<TransportTypeDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public TransportTypeDTO updateRecord(TransportTypeDTO record)
        {
            TransportTypeApplicationMapper mapper = new TransportTypeApplicationMapper();
            TransportTypeDbModel dbModel = mapper.DTOToDbModelMapper(record);
            TransportTypeDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}