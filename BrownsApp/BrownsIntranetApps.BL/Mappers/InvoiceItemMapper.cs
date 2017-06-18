using BrownsIntranetApps.DTO;
using BrownsIntranetApps.Entity.SQL;
using System;

namespace BrownsIntranetApps.BL.Mappers
{
    public class InvoiceItemMapper
    {
        public InvoiceItemsDTO InvoiceItemDTOMapper(InvoiceItem invoiceItem)
        {
            return new InvoiceItemsDTO
            {
                ID = invoiceItem.ID,
                InvoiceID = invoiceItem.InvoiceID,
                Price = Math.Round(invoiceItem.Price, 2),
                Quantity = invoiceItem.Quantity,
                Total = Math.Round(invoiceItem.Total, 2),
                Description = invoiceItem.Description,
                RecordStatus = "Active"
            };
        }

        public InvoiceItem InvoiceItemEntityMapper(InvoiceItemsDTO invoiceItem)
        {
            return new InvoiceItem
            {
                ID = invoiceItem.ID,
                InvoiceID = invoiceItem.InvoiceID,
                Price = Math.Round(invoiceItem.Price, 2),
                Quantity = Math.Round(invoiceItem.Quantity,2),
                Description = invoiceItem.Description,
                Total = Math.Round(invoiceItem.Total, 2),
                AddedDate = DateTime.Now,
                AddedBy = "Admin"
            };
        }
    }
}