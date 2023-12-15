using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Core
{
    public class DeliveryStatusImpRepository : IDeliveryStatusRepository
    {
        public DeliveryStatusDbModel createRecord(DeliveryStatusDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                var docType = db.EstadoEnvio.Where(x => x.Nombre.ToUpper().Trim().Equals(record.Name.ToUpper().Trim())).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                DeliveryStatusRepositoryMapper mapper = new DeliveryStatusRepositoryMapper();
                EstadoEnvio dt = mapper.DbModelToDataBaseMapper(record);
                db.EstadoEnvio.Add(dt);
                db.SaveChanges();
                return mapper.DataBaseToDbModelMapper(dt);

            }
        }

        /// <summary>
        /// Eliminación de un registro en la base de datos por Id
        /// </summary>
        /// <param name="id">Id del registro a eliminar</param>
        /// <returns>Booleano, true cuando se elimina y false cuando no se encuentra o está asociado como FK</returns>
        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    EstadoEnvio record = db.EstadoEnvio.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.EstadoEnvio.Remove(record);
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
        /// <param name="id">Id del registro a buscar</param>
        /// <returns>null cuando no lo encuentra o el objeto cunado si lo encuentra</returns>
        public DeliveryStatusDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                EstadoEnvio record = db.EstadoEnvio.Find(id);
                if (record == null)
                {
                    return null;
                }
                DeliveryStatusRepositoryMapper mapper = new DeliveryStatusRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<DeliveryStatusDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<EstadoEnvio> list = db.EstadoEnvio.Where(x => x.Nombre.Contains(filter));
                DeliveryStatusRepositoryMapper mapper = new DeliveryStatusRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(list);
            }
        }

        public DeliveryStatusDbModel updateRecord(DeliveryStatusDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                EstadoEnvio td = db.EstadoEnvio.Where(x => x.Id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.Nombre = record.Name;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    DeliveryStatusRepositoryMapper mapper = new DeliveryStatusRepositoryMapper();

                    return mapper.DataBaseToDbModelMapper(td);
                }
            }
        }
    }
}