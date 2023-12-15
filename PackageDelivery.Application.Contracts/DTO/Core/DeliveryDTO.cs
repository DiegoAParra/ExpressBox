using System;

namespace PackageDelivery.Application.Contracts.DTO.Core
{
    public class DeliveryDTO
    {
        public long Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Price { get; set; }
        public long Id_DestinationAddress { get; set; }
        public long Id_Package { get; set; }
        public long Id_DeliveryStatus { get; set; }
        public long Id_Sender { get; set; }
        public long Id_TransportType { get; set; }
        public string DestinationAddressName { get; set; }
        public string PackageName { get; set; }
        public string DeliveryStatusName { get; set; }
        public string SenderName { get; set; }
        public string TransportTypeName { get; set; }
    }
}
