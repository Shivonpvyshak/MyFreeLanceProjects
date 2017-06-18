using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownsIntranetApps.DTO
{
    public class RepairHomeDTO
    {
        public int Id { get; set; }
        public string RepairType { get; set; }
        public string RepairNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date_Time { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string UnitNumber { get; set; }
        public string SerialNumber { get; set; }
        public decimal MachineHours { get; set; }
        public decimal MachineMiles { get; set; }
        public decimal TotalBill { get; set; }
        public decimal Labor { get; set; }
        public decimal Parts { get; set; }
        public decimal PartsCost { get; set; }
        public decimal LaborHours { get; set; }
       
    }
}
