namespace PackageDelivery.Application.Contracts.DTO.Parameters
{
    public class AddressDTO
    {
        public long Id { get; set; }
        public bool Current { get; set; }
        public string StreetType { get; set; }
        public string Number { get; set; }
        public string PropertyType { get; set; }
        public string Neighborhood { get; set; }
        public string Observations { get; set; }
        public long Id_Person { get; set; }
        public long Id_City { get; set; }
        public string PersonName { get; set; }
        public string CityName { get; set; }
    }
}