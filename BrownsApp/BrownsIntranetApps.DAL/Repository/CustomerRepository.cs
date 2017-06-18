using BrownsIntranetApps.DAL.Interface;
using BrownsIntranetApps.Entity.SQL;
using System.Linq;

namespace BrownsIntranetApps.DAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private BrownsAppDBEntities1 _bheDBContext;

        public CustomerRepository(BrownsAppDBEntities1 bheDBContext)
        {
            _bheDBContext = bheDBContext;
        }

        public int Add(Customer customer)
        {
            return _bheDBContext.Customers.Add(customer).ID;
        }

        public int Delete(Customer customer)
        {
            _bheDBContext.Customers.Attach(customer);
            return _bheDBContext.Customers.Remove(customer).ID;
        }

        public int Delete(int id)
        {
            var existing = _bheDBContext.Customers.Find(id);
            if(existing != null)
            {
                if (existing.Invoices.Count > 0)
                {

                }
                _bheDBContext.Entry(existing).State = System.Data.Entity.EntityState.Deleted;
            }
            return id;
        }

        public IQueryable<Customer> Query()
        {
            return _bheDBContext.Customers;
        }
    }
}