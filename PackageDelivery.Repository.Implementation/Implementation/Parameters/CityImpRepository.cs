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
    public class CityImpRepository : ICityRepository
    {
        public CityDbModel createRecord(CityDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                var docType = db.Municipio.Where(x => x.Nombre.ToUpper().Trim().Equals(record.Name.ToUpper().Trim())).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                CityRepositoryMapper mapper = new CityRepositoryMapper();
                Municipio dt = mapper.DbModelToDataBaseMapper(record);
                db.Municipio.Add(dt);
                db.SaveChanges();
                Municipio mu = db.Municipio.Find(dt.Id);
                CityDbModel m = mapper.DataBaseToDbModelMapper(db.Municipio.Find(dt.Id));
                return m;
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
                    Municipio record = db.Municipio.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.Municipio.Remove(record);
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
        public CityDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Municipio record = db.Municipio.Find(id);
                if (record == null)
                {
                    return null;
                }
                CityRepositoryMapper mapper = new CityRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<CityDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<Municipio> list = db.Municipio.Where(x => x.Nombre.Contains(filter));
                CityRepositoryMapper mapper = new CityRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(list);
            }
        }

        public CityDbModel updateRecord(CityDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Municipio td = db.Municipio.Where(x => x.Id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.Nombre = record.Name;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    CityRepositoryMapper mapper = new CityRepositoryMapper();

                    return mapper.DataBaseToDbModelMapper(td);
                }
            }
        }
    }
}