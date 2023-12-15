namespace PackageDelivery.Repository.Contracts.DbModels.Parameters
{
    public class WarehouseDbModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }
        public string Code { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public long Id_City { get; set; }
        public string CityName { get; set; }
    }
}
