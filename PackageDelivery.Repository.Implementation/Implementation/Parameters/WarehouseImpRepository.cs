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
    public class WarehouseImpRepository : IWarehouseRepository
    {
        public WarehouseDbModel createRecord(WarehouseDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                var docType = db.Bodega.Where(x => x.Codigo.ToUpper().Trim().Equals(record.Code.ToUpper().Trim())).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                WarehouseRepositoryMapper mapper = new WarehouseRepositoryMapper();
                Bodega dt = mapper.DbModelToDataBaseMapper(record);
                db.Bodega.Add(dt);
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
                    Bodega record = db.Bodega.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.Bodega.Remove(record);
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
        public WarehouseDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Bodega record = db.Bodega.Find(id);
                if (record == null)
                {
                    return null;
                }
                WarehouseRepositoryMapper mapper = new WarehouseRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<WarehouseDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<Bodega> list = db.Bodega.Where(x => x.Nombre.Contains(filter));
                WarehouseRepositoryMapper mapper = new WarehouseRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(list);
            }
        }

        public WarehouseDbModel updateRecord(WarehouseDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Bodega td = db.Bodega.Where(x => x.Id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.Nombre = record.Name;
                    td.Direccion = record.Direction;
                    td.Codigo = record.Code;
                    td.latitud = record.Latitude;
                    td.longitud = record.Longitude;
                    td.Id_Municipio = record.Id_City;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    WarehouseRepositoryMapper mapper = new WarehouseRepositoryMapper();

                    return mapper.DataBaseToDbModelMapper(td);
                }
            }
        }
    }
}