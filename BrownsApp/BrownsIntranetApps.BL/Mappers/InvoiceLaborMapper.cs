using BrownsIntranetApps.DTO;
using BrownsIntranetApps.Entity.SQL;
using System;

namespace BrownsIntranetApps.BL.Mappers
{
    public class InvoiceLaborMapper
    {
        public InvoiceLaborDTO InvoiceLaborDTOMapper(InvoiceLabor invoiceLabor)
        {
            InvoiceLaborDTO invoiceLaborDTO = new InvoiceLaborDTO();
            invoiceLaborDTO.LaborType = new TypeCodeDTO();
            invoiceLaborDTO.LaborType.TypeCode = invoiceLabor.LaborType;
            invoiceLaborDTO.ID = invoiceLabor.ID;
            invoiceLabor.InvoiceID = invoiceLabor.InvoiceID;
            invoiceLaborDTO.Amount = Math.Round(invoiceLabor.Amount.GetValueOrDefault(), 2);
            invoiceLaborDTO.Hours = invoiceLabor.Hours;
            invoiceLaborDTO.Rate = invoiceLabor.Rate;
            invoiceLaborDTO.RecordStatus = "Active";

            return invoiceLaborDTO;
        }

        public InvoiceLabor InvoiceLaborEntityMapper(InvoiceLaborDTO invoiceLabor)
        {
            return new InvoiceLabor
            {
                ID = invoiceLabor.ID,
                InvoiceID = invoiceLabor.InvoiceID,
                Amount = invoiceLabor.Amount,
                Hours = invoiceLabor.Hours,
                LaborType = invoiceLabor.LaborType!=null?invoiceLabor.LaborType.TypeCode:"",
                Rate = invoiceLabor.Rate,
                AddedDate = DateTime.Now,
                AddedBy = "Admin"
            };
        }
    }
}