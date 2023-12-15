using PackageDelivery.Application.Contracts.DTO.Core;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Mappers.Core;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
    public class DeliveryStatusImpApplication : IDeliveryStatusApplication
    {
        IDeliveryStatusRepository _repository;
        public DeliveryStatusImpApplication(IDeliveryStatusRepository repository)
        {
            this._repository = repository;
        }
        public DeliveryStatusDTO createRecord(DeliveryStatusDTO record)
        {
            DeliveryStatusApplicationMapper mapper = new DeliveryStatusApplicationMapper();
            DeliveryStatusDbModel dbModel = mapper.DTOToDbModelMapper(record);
            DeliveryStatusDbModel response = this._repository.createRecord(dbModel);
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

        public DeliveryStatusDTO getRecordById(int id)
        {
            DeliveryStatusApplicationMapper mapper = new DeliveryStatusApplicationMapper();
            DeliveryStatusDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<DeliveryStatusDTO> getRecordList(string filter)
        {
            DeliveryStatusApplicationMapper mapper = new DeliveryStatusApplicationMapper();
            IEnumerable<DeliveryStatusDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public DeliveryStatusDTO updateRecord(DeliveryStatusDTO record)
        {
            DeliveryStatusApplicationMapper mapper = new DeliveryStatusApplicationMapper();
            DeliveryStatusDbModel dbModel = mapper.DTOToDbModelMapper(record);
            DeliveryStatusDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}