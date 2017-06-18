using System;
using System.Collections.Generic;

namespace BrownsIntranetApps.DTO
{
    public class InvoiceDTO : BaseDTO
    {
        public string InvoiceType { get; set; }
        public int CustomerID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string OrderNumber { get; set; }
        public string SalesRep { get; set; }

        public string CustomerPO { get; set; }
        public decimal PartsSubTotal { get; set; }
        public decimal LaborSubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal? Freight { get; set; }
        public decimal Total { get; set; }
        public decimal? BalanceDue { get; set; }
        public string Comments { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string UnitNumber { get; set; }
        public decimal? TravelCharge { get; set; }
        public decimal? TravelExpense { get; set; }

        public TypeCodeDTO InvoiceStatus { get; set; }
        public TypeCodeDTO ShippingMethod { get; set; }
        public TypeCodeDTO PaymentStatus { get; set; }

        public TypeCodeDTO County { get; set; }

        public CustomerDTO Customer { get; set; }

        public IList<InvoiceItemsDTO> InvoiceItems { get; set; }

        public IList<InvoiceLaborDTO> InvoiceLabors { get; set; }

        public string SubmitingMode { get; set; }

        public DateTime ServiceStartDate { get; set; }

        public DateTime ServiceEndDate { get; set; }

        public string ServicedAt { get; set; }
        public bool IsStorePickUp { get; set; }
    }
}