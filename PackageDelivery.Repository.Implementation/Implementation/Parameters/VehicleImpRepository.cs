using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Parameters
{
    public class VehicleImpRepository : IVehicleRepository
    {
        public VehicleDbModel createRecord(VehicleDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                var vehicle = db.vehiculo.Where(x => x.placa.ToUpper().Trim().Equals(record.Plate.ToUpper().Trim())).FirstOrDefault();
                if (vehicle != null)
                {
                    return null;
                }
                VehicleRepositoryMapper mapper = new VehicleRepositoryMapper();
                vehiculo dt = mapper.DbModelToDataBaseMapper(record);
                db.vehiculo.Add(dt);
                db.SaveChanges();
                return mapper.DataBaseToDbModelMapper(dt);

            }
        }

        /// <summary>
        /// Eliminación de un registro en la base de datos por Id
        /// </summary>
        /// <param Plate="id">Id del registro a eliminar</param>
        /// <returns>Booleano, true cuando se elimina y false cuando no se encuentra o está asociado como FK</returns>
        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    vehiculo record = db.vehiculo.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.vehiculo.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Obtiene el registro por Id
        /// </summary>
        /// <param Plate="id">Id del registro a buscar</param>
        /// <returns>null cuando no lo encuentra o el objeto cunado si lo encuentra</returns>
        public VehicleDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                vehiculo record = db.vehiculo.Find(id);
                if (record == null)
                {
                    return null;
                }
                VehicleRepositoryMapper mapper = new VehicleRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param Plate="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<VehicleDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<vehiculo> list = db.vehiculo.Where(x => x.placa.Contains(filter));
                VehicleRepositoryMapper mapper = new VehicleRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(list);
            }
        }

        public VehicleDbModel updateRecord(VehicleDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                vehiculo td = db.vehiculo.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.placa = record.Plate;
                    td.idTipoTransporte = record.IdTransportType;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    VehicleRepositoryMapper mapper = new VehicleRepositoryMapper();

                    return mapper.DataBaseToDbModelMapper(td);
                }
            }
        }
    }
}