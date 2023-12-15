using System;

namespace PackageDelivery.Application.Contracts.DTO.Core
{
    public class PackageHistoryDTO
    {
        public long Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime DepurateDate { get; set; }
        public string Description { get; set; }
        public long Id_Package { get; set; }
        public long Id_Warehouse { get; set; }
        public string PackageName { get; set; }
        public string WarehouseName { get; set; }
    }
}
