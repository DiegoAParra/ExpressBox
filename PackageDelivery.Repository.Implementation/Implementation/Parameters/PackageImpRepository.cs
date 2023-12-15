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
    public class PackageImpRepository : IPackageRepository
    {
        public PackageDbModel createRecord(PackageDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Paquete codNumber = db.Paquete.Where(x => (x.Id).Equals(record.Id)).FirstOrDefault();
                if (codNumber != null)
                {
                    return null;
                }
                PackageRepositoryMapper mapper = new PackageRepositoryMapper();
                Paquete dt = mapper.DbModelToDataBaseMapper(record);
                db.Paquete.Add(dt);
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
                    Paquete record = db.Paquete.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.Paquete.Remove(record);
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
        public PackageDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Paquete record = db.Paquete.Find(id);
                if (record == null)
                {
                    return null;
                }
                PackageRepositoryMapper mapper = new PackageRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param IdentificationNumber="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<PackageDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<Paquete> list = db.Paquete.Where(x => (x.Id + "").Contains(filter));
                PackageRepositoryMapper mapper = new PackageRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(list);
            }
        }

        public PackageDbModel updateRecord(PackageDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Paquete td = db.Paquete.Where(x => x.Id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.Altura = record.Height;
                    td.Ancho = record.Width;
                    td.Profundidad = record.Depth;
                    td.Peso = record.Weight;
                    td.Id_Oficina = record.Id_Office;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    PackageRepositoryMapper mapper = new PackageRepositoryMapper();

                    return mapper.DataBaseToDbModelMapper(td);
                }
            }
        }
    }
}