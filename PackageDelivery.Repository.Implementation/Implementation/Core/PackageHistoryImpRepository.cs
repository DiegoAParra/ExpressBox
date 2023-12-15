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
    public class PackageHistoryImpRepository : IPackageHistoryRepository
    {
        public PackageHistoryDbModel createRecord(PackageHistoryDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                var docType = db.Historial.Where(x => x.Id.Equals(record.Id)).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                PackageHistoryRepositoryMapper mapper = new PackageHistoryRepositoryMapper();
                Historial dt = mapper.DbModelToDataBaseMapper(record);
                db.Historial.Add(dt);
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
                    Historial record = db.Historial.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.Historial.Remove(record);
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
        public PackageHistoryDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Historial record = db.Historial.Find(id);
                if (record == null)
                {
                    return null;
                }
                PackageHistoryRepositoryMapper mapper = new PackageHistoryRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<PackageHistoryDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<Historial> list = db.Historial.Where(x => (x.Id + "").Contains(filter));
                PackageHistoryRepositoryMapper mapper = new PackageHistoryRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(list);
            }
        }

        public PackageHistoryDbModel updateRecord(PackageHistoryDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Historial td = db.Historial.Where(x => x.Id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.FechaIngreso = record.AdmissionDate;
                    td.FechaSalida = record.DepurateDate;
                    td.Descripcion = record.Description;
                    td.Id_Paquete = record.Id_Package;
                    td.Id_Bodega = record.Id_Warehouse;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    PackageHistoryRepositoryMapper mapper = new PackageHistoryRepositoryMapper();

                    return mapper.DataBaseToDbModelMapper(td);
                }
            }
        }
    }
}