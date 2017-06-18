using BrownsIntranetApps.Entity.SQL;
using System.Linq;

namespace BrownsIntranetApps.DAL.Interface
{
    public interface IInvoiceItemsRepository
    {
        long Add(InvoiceItem invoiceItem);

        IQueryable<InvoiceItem> Query();

        long Delete(InvoiceItem invoiceItem);
    }
}