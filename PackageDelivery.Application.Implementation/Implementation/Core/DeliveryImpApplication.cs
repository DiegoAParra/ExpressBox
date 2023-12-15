using PackageDelivery.Application.Contracts.DTO.Core;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Core;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class DeliveryImpApplication : IDeliveryApplication
    {
        IDeliveryRepository _repository;
        public DeliveryImpApplication(IDeliveryRepository repository)
        {
            this._repository = repository;
        }
        public DeliveryDTO createRecord(DeliveryDTO record)
        {
            DeliveryApplicationMapper mapper = new DeliveryApplicationMapper();
            DeliveryDbModel dbModel = mapper.DTOToDbModelMapper(record);
            DeliveryDbModel response = this._repository.createRecord(dbModel);
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

        public DeliveryDTO getRecordById(int id)
        {
            DeliveryApplicationMapper mapper = new DeliveryApplicationMapper();
            DeliveryDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<DeliveryDTO> getRecordList(string filter)
        {
            DeliveryApplicationMapper mapper = new DeliveryApplicationMapper();
            IEnumerable<DeliveryDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public DeliveryDTO updateRecord(DeliveryDTO record)
        {
            DeliveryApplicationMapper mapper = new DeliveryApplicationMapper();
            DeliveryDbModel dbModel = mapper.DTOToDbModelMapper(record);
            DeliveryDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}