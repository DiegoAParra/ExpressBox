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
    public class AddressImpRepository : IAddressRepository
    {
        public AddressDbModel createRecord(AddressDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Direccion codNumber = db.Direccion.Where(x => (x.Id).Equals(record.Id)).FirstOrDefault();
                if (codNumber != null)
                {
                    return null;
                }
                AddressRepositoryMapper mapper = new AddressRepositoryMapper();
                Direccion dt = mapper.DbModelToDataBaseMapper(record);
                db.Direccion.Add(dt);
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
                    Direccion record = db.Direccion.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.Direccion.Remove(record);
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
        public AddressDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Direccion record = db.Direccion.Find(id);
                if (record == null)
                {
                    return null;
                }
                AddressRepositoryMapper mapper = new AddressRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param IdentificationNumber="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<AddressDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<Direccion> list = db.Direccion.Where(x => (x.Id + "").Contains(filter));
                AddressRepositoryMapper mapper = new AddressRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(list);
            }
        }

        public AddressDbModel updateRecord(AddressDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Direccion td = db.Direccion.Where(x => x.Id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.Numero = record.Number;
                    td.Actual = record.Current;
                    td.TipoCalle = record.StreetType;
                    td.TipoInmueble = record.PropertyType;
                    td.Barrio = record.Neighborhood;
                    td.Observaciones = record.Observations;
                    td.Id_Municipio = record.Id_City;
                    td.Id_Persona = record.Id_Person;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    AddressRepositoryMapper mapper = new AddressRepositoryMapper();

                    return mapper.DataBaseToDbModelMapper(td);
                }
            }
        }
    }
}