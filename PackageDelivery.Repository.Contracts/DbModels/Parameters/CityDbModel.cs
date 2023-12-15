
namespace PackageDelivery.Repository.Contracts.DbModels.Parameters
{
    public class CityDbModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Id_Department { get; set; }
        public string DepartmentName { get; set; }
    }
}
