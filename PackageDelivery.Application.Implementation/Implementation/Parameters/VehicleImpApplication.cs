using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class VehicleImpApplication : IVehicleApplication
    {
        IVehicleRepository _repository;
        public VehicleImpApplication(IVehicleRepository repository)
        {
            this._repository = repository;
        }
        public VehicleDTO createRecord(VehicleDTO record)
        {
            VehicleApplicationMapper mapper = new VehicleApplicationMapper();
            VehicleDbModel dbModel = mapper.DTOToDbModelMapper(record);
            VehicleDbModel response = this._repository.createRecord(dbModel);
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

        public VehicleDTO getRecordById(int id)
        {
            VehicleApplicationMapper mapper = new VehicleApplicationMapper();
            VehicleDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<VehicleDTO> getRecordList(string filter)
        {
            VehicleApplicationMapper mapper = new VehicleApplicationMapper();
            IEnumerable<VehicleDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public VehicleDTO updateRecord(VehicleDTO record)
        {
            VehicleApplicationMapper mapper = new VehicleApplicationMapper();
            VehicleDbModel dbModel = mapper.DTOToDbModelMapper(record);
            VehicleDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}