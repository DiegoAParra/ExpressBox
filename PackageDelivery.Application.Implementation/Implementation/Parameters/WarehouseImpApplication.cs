using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class WarehouseImpApplication : IWarehouseApplication
    {
        IWarehouseRepository _repository;
        public WarehouseImpApplication(IWarehouseRepository repository)
        {
            this._repository = repository;
        }
        public WarehouseDTO createRecord(WarehouseDTO record)
        {
            WarehouseApplicationMapper mapper = new WarehouseApplicationMapper();
            WarehouseDbModel dbModel = mapper.DTOToDbModelMapper(record);
            WarehouseDbModel response = this._repository.createRecord(dbModel);
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

        public WarehouseDTO getRecordById(int id)
        {
            WarehouseApplicationMapper mapper = new WarehouseApplicationMapper();
            WarehouseDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<WarehouseDTO> getRecordList(string filter)
        {
            WarehouseApplicationMapper mapper = new WarehouseApplicationMapper();
            IEnumerable<WarehouseDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public WarehouseDTO updateRecord(WarehouseDTO record)
        {
            WarehouseApplicationMapper mapper = new WarehouseApplicationMapper();
            WarehouseDbModel dbModel = mapper.DTOToDbModelMapper(record);
            WarehouseDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}