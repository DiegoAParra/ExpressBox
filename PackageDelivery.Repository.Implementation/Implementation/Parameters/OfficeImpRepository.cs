using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace PackageDelivery.Repository.Implementation.Parameters
{
    public class OfficeImpRepository : IOfficeRepository
    {
        public OfficeDbModel createRecord(OfficeDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Oficina codNumber = db.Oficina.Where(x => (x.Codigo).Equals(record.Code)).FirstOrDefault();
                if (codNumber != null)
                {
                    return null;
                }
                OfficeRepositoryMapper mapper = new OfficeRepositoryMapper();
                Oficina dt = mapper.DbModelToDataBaseMapper(record);
                db.Oficina.Add(dt);
                db.SaveChanges();
                return mapper.DataBaseToDbModelMapper(dt);

            }
        }

        /// <summary>
        /// Eliminación de un registro en la base de datos por Id
        /// </summary>
        /// <param IdentificationNumber="id">Id del registro a eliminar</param>
        /// <returns>Booleano, true cuando se elimina y false cuando no se encuentra o está asociado como FK</returns>
        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    Oficina record = db.Oficina.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.Oficina.Remove(record);
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
        /// <param IdentificationNumber="id">Id del registro a buscar</param>
        /// <returns>null cuando no lo encuentra o el objeto cunado si lo encuentra</returns>
        public OfficeDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Oficina record = db.Oficina.Find(id);
                if (record == null)
                {
                    return null;
                }
                OfficeRepositoryMapper mapper = new OfficeRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param IdentificationNumber="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<OfficeDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<Oficina> list = db.Oficina.Where(x => (x.Codigo + "").Contains(filter));
                OfficeRepositoryMapper mapper = new OfficeRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(list);
            }
        }

        public OfficeDbModel updateRecord(OfficeDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Oficina td = db.Oficina.Where(x => x.Id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.Codigo = record.Code;
                    td.Direccion = record.Direction;
                    td.Nombre = record.Name;
                    td.Telefono = record.CellPhone;
                    td.Latitud = record.Latitude;
                    td.Longitud = record.Longitude;
                    td.Id_Municipio = record.Id_City;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    OfficeRepositoryMapper mapper = new OfficeRepositoryMapper();

                    return mapper.DataBaseToDbModelMapper(td);
                }
            }
        }
    }
}