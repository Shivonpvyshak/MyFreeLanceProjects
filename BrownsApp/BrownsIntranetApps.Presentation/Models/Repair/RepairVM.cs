using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BrownsIntranetApps.Presentation.Models.Repair
{
    public class RepairVM
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Repair #")]
        public string RepairNumber { get; set; }

        [Required]
        [DisplayName("Repair Type")]
        public string RepairType { get; set; }

        public int CustomerId { get; set; }
        [Required]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

       // [Required]
        [DisplayName("Invoice Date")]
        [DataType(DataType.Date)]
        public DateTime? InvoiceDate { get; set; }

        [Required]
        [DisplayName("Make")]
        public string Make { get; set; }
        [Required]
        [DisplayName("Model")]
        public string MachineModel { get; set; }

        [DisplayName("Unit NUmber")]
        public string UnitNumber { get; set; }

        [DisplayName("Serial Number")]
        public string SerialNumber { get; set; }

        [DisplayName("Machine Hours")]
        public decimal? MachineHours { get; set; }

        [DisplayName("Machine Miles")]
        public decimal? MachineMiles { get; set; }

        [DisplayName("Total Bill")]
        [DataType(DataType.Currency)]
        [DefaultValue(0.0)]
        public decimal? TotalBill { get; set; }

        [DisplayName("Labor")]
        [DataType(DataType.Currency)]

        public decimal? Labor { get; set; }
        public decimal? Parts { get; set; }

        [DisplayName("Parts Cost")]
        [DataType(DataType.Currency)]
        public decimal? PartsCost { get; set; }

        [DisplayName("Labor Hours")]        
        public decimal? LaborHours { get; set; }
        public string VendorInvoicesFile { get; set; }
        public string ServiceReportBillFile { get; set; }
        public HttpPostedFileBase VendorInvoicesFileBase { get; set; }
        public HttpPostedFileBase ServiceReportBillFileBase { get; set; }

        public List<string> RepairTypes { get; } = new List<string> {
            "Maintenance",
            "Preventative Maintenance",
            "Inspection",
            "Miscellaneous Repair",
            "Electrical",
            "Line Boring",
            "Paint",
            "Component Repair - Brakes",
            "Component Repair - Engine",
            "Component Repair - Transmission",
            "Component Repair - Gear Box",
            "Component Repair - Steering",
            "Component Repair - Differential",
            "Component Repair - Torque Converter",
            "Component Repair - Pumps",
            "Component Repair – Hydraulic Cylinder",
            "Component Repair – Hydraulic Pump",
            "Component Repair – Hydraulic Hoses",
            "Component Repair - Coolant System",
            "Component Repair - Undercarriage",
            "Component Repair - Boom",
            "Component Repair - A/C & Heating",
            "Component Rebuild – Complete",
            "Component Rebuild – Drive Train",
            "Component Rebuild – Engine",
            "Component Rebuild – Transmission",
            "Component Rebuild – Gear Box",
            "Component Rebuild – Final Drive",
            "Component Rebuild – Torque Converter",
            "Component Rebuild – Differential",

        };
    }
}