using BrownsIntranetApps.Entity.SQL;
using System.Linq;

namespace BrownsIntranetApps.DAL.Interface
{
    public interface IInvoiceLaborRepository
    {
        long Add(InvoiceLabor labor);

        IQueryable<InvoiceLabor> Query();

        long Delete(InvoiceLabor labor);
    }
}