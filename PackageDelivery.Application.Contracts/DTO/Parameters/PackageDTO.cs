namespace PackageDelivery.Application.Contracts.DTO.Parameters
{
    public class PackageDTO
    {
        public long Id { get; set; }
        public int Weight { get; set; }
        public int Depth { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public long Id_Office { get; set; }
        public string OfficeName { get; set; }
    }
}