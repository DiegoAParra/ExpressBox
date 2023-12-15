using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Core
{
    public class DeliveryRepositoryMapper : DbModelMapperBase<DeliveryDbModel, Envio>
    {
        public override DeliveryDbModel DataBaseToDbModelMapper(Envio input)
        {
            return new DeliveryDbModel()
            {
                Id = input.Id,
                DeliveryDate = input.FechaEnvio,
                Price = input.Precio,
                Id_DestinationAddress = input.Id_DireccionDestino,
                Id_Package = input.Id_Paquete,
                Id_DeliveryStatus = input.Id_EstadoEnvio,
                Id_Sender = input.Id_Remitente,
                Id_TransportType = input.Id_TipoTransporte,
                DestinationAddressName = input.Direccion != null ? input.Direccion.TipoCalle + " " + input.Direccion.Numero + " " + input.Direccion.Barrio : string.Empty,
                PackageName = input.Paquete != null ? input.Paquete.Id + "" : string.Empty,
                DeliveryStatusName = input.EstadoEnvio != null ? input.EstadoEnvio.Nombre : string.Empty,
                SenderName = input.Persona != null ? input.Persona.Documento : string.Empty,
                TransportTypeName = input.TipoTransporte != null ? input.TipoTransporte.nombre : string.Empty

                
            };
        }

        public override IEnumerable<DeliveryDbModel> DataBaseToDbModelMapper(IEnumerable<Envio> input)
        {
            IList<DeliveryDbModel> list = new List<DeliveryDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DataBaseToDbModelMapper(item));
            }
            return list;
        }

        public override Envio DbModelToDataBaseMapper(DeliveryDbModel input)
        {
            return new Envio()
            {
                Id = input.Id,
                FechaEnvio = input.DeliveryDate,
                Precio = input.Price,
                Id_DireccionDestino = input.Id_DestinationAddress,
                Id_Paquete = input.Id_Package,
                Id_EstadoEnvio = input.Id_DeliveryStatus,
                Id_Remitente = input.Id_Sender,
                Id_TipoTransporte = input.Id_TransportType
            };
        }

        public override IEnumerable<Envio> DbModelToDataBaseMapper(IEnumerable<DeliveryDbModel> input)
        {
            IList<Envio> list = new List<Envio>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDataBaseMapper(item));
            }
            return list;
        }
    }
}
