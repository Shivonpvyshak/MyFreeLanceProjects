using BrownsIntranetApps.Entity.SQL;
using System.Linq;

namespace BrownsIntranetApps.DAL.Interface
{
    public interface IRepairRepository
    {
        int Add(Repair repair);

        IQueryable<Repair> Query();

        int Delete(Repair customer);
        int Delete(int id);
    }
}