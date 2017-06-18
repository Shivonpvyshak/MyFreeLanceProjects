using BrownsIntranetApps.DAL.Interface;
using BrownsIntranetApps.Entity.SQL;
using System.Linq;

namespace BrownsIntranetApps.DAL.Repository
{
    public class InvoiceItemsRepository : IInvoiceItemsRepository
    {
        private BrownsAppDBEntities1 _bheDBContext;

        public InvoiceItemsRepository(BrownsAppDBEntities1 bheDBContext)
        {
            _bheDBContext = bheDBContext;
        }

        public long Add(InvoiceItem invoiceItem)
        {
            return _bheDBContext.InvoiceItems.Add(invoiceItem).ID;
        }

        public long Delete(InvoiceItem invoiceItem)
        {
            _bheDBContext.InvoiceItems.Attach(invoiceItem);
            return _bheDBContext.InvoiceItems.Remove(invoiceItem).ID;
        }

        public IQueryable<InvoiceItem> Query()
        {
            return _bheDBContext.InvoiceItems;
        }
    }
}