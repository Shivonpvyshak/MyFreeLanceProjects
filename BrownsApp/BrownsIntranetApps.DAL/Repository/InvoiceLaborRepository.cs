using BrownsIntranetApps.DAL.Interface;
using BrownsIntranetApps.Entity.SQL;
using System.Linq;

namespace BrownsIntranetApps.DAL.Repository
{
    public class InvoiceLaborRepository : IInvoiceLaborRepository
    {
        private BrownsAppDBEntities1 _bheDBContext;

        public InvoiceLaborRepository(BrownsAppDBEntities1 bheDBContext)
        {
            _bheDBContext = bheDBContext;
        }

        public long Add(InvoiceLabor labor)
        {
            return _bheDBContext.InvoiceLabors.Add(labor).ID;
        }

        public long Delete(InvoiceLabor labor)
        {
            _bheDBContext.InvoiceLabors.Attach(labor);
            return _bheDBContext.InvoiceLabors.Remove(labor).ID;
        }

        public IQueryable<InvoiceLabor> Query()
        {
            return _bheDBContext.InvoiceLabors;
        }
    }
}