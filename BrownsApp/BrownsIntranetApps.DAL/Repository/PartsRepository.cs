using BrownsIntranetApps.DAL.Interface;
using BrownsIntranetApps.Entity.SQL;
using System.Linq;

namespace BrownsIntranetApps.DAL.Repository
{
    public class PartsRepository : IPartsRepository
    {
        private BrownsAppDBEntities1 _bheDBContext;

        public PartsRepository(BrownsAppDBEntities1 bheDBContext)
        {
            _bheDBContext = bheDBContext;
        }

        public long Add(Part part)
        {
            return _bheDBContext.Parts.Add(part).ID;
        }

        public IQueryable<Part> Query()
        {
            return _bheDBContext.Parts;
        }

        public long Delete(Part part)
        {
            _bheDBContext.Parts.Attach(part);
            return _bheDBContext.Parts.Remove(part).ID;
        }
    }
}