using BrownsIntranetApps.Entity.SQL;
using System.Linq;

namespace BrownsIntranetApps.DAL.Interface
{
    public interface ICustomerRepository
    {
        int Add(Customer customer);

        IQueryable<Customer> Query();

        int Delete(Customer customer);

        int Delete(int id);
    }
}