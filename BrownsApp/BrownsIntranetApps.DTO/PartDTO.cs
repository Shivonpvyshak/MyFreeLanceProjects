namespace BrownsIntranetApps.DTO
{
    public class PartDTO : BaseDTO
    {
        public long ID { get; set; }
        public int CompanyID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string SerialNumberRange { get; set; }
        public string PartNumber { get; set; }
        public string PartDescription { get; set; }
        public string PartManual { get; set; }
        public string ListPrice { get; set; }
    }
}