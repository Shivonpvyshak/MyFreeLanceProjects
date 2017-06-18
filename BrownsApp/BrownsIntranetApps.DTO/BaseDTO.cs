using System;

namespace BrownsIntranetApps.DTO
{
    public abstract class BaseDTO
    {
        public int ID { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public int IsDeleted { get; set; }
    }
}