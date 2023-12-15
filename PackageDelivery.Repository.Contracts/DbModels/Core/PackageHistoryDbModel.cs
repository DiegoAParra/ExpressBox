using System;

namespace PackageDelivery.Repository.Contracts.DbModels.Core
{
    public class PackageHistoryDbModel
    {
        public long Id { get; set; }
        public DateTime  AdmissionDate{ get; set; }
        public DateTime DepurateDate { get; set; }
        public string Description { get; set; }
        public long Id_Package { get; set; }
        public long Id_Warehouse { get; set; }
        public string PackageName { get; set; }
        public string WarehouseName { get; set; }
    }
}
