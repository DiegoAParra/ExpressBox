using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Parameters
{
    public class DeliveryImpRepository : IDeliveryRepository
    {
        public DeliveryDbModel createRecord(DeliveryDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                var docType = db.Envio.Where(x => x.Id.Equals(record.Id)).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                DeliveryRepositoryMapper mapper = new DeliveryRepositoryMapper();
                Envio dt = mapper.DbModelToDataBaseMapper(record);
                db.Envio.Add(dt);
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
                    Envio record = db.Envio.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.Envio.Remove(record);
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
        public DeliveryDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Envio record = db.Envio.Find(id);
                if (record == null)
                {
                    return null;
                }
                DeliveryRepositoryMapper mapper = new DeliveryRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<DeliveryDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<Envio> list = db.Envio.Where(x => (x.Id+"").Contains(filter));
                DeliveryRepositoryMapper mapper = new DeliveryRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(list);
            }
        }

        public DeliveryDbModel updateRecord(DeliveryDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Envio td = db.Envio.Where(x => x.Id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.FechaEnvio = record.DeliveryDate;
                    td.Precio = record.Price;
                    td.Id_DireccionDestino = record.Id_DestinationAddress;
                    td.Id_Paquete = record.Id_Package;
                    td.Id_EstadoEnvio = record.Id_DeliveryStatus;
                    td.Id_Remitente = record.Id_Sender;
                    td.Id_TipoTransporte = record.Id_TransportType;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    DeliveryRepositoryMapper mapper = new DeliveryRepositoryMapper();

                    return mapper.DataBaseToDbModelMapper(td);
                }
            }
        }
    }
}