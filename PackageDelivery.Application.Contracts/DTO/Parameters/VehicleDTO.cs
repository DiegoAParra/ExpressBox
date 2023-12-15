namespace PackageDelivery.Application.Contracts.DTO.Parameters
{
    public class VehicleDTO
    {
        public long Id { get; set; }
        public string Plate { get; set; }
        public long IdTransportType { get; set; }
        public string TransportTypeName { get; set; }
    }
}
