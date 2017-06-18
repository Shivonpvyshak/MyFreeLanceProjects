using BrownsIntranetApps.Entity.SQL;
using System.Linq;

namespace BrownsIntranetApps.DAL.Interface
{
    public interface IPartsRepository
    {
        long Add(Part part);

        IQueryable<Part> Query();

        long Delete(Part part);
    }
}