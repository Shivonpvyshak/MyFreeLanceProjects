using BrownsIntranetApps.DAL.Interface;
using BrownsIntranetApps.Entity.SQL;
using System.Linq;

namespace BrownsIntranetApps.DAL.Repository
{
    public class RepairRepository : IRepairRepository
    {
        private BrownsAppDBEntities1 _bheDBContext;

        public RepairRepository(BrownsAppDBEntities1 bheDBContext)
        {
            _bheDBContext = bheDBContext;
        }

        public int Add(Repair repair)
        {
            return _bheDBContext.Repairs.Add(repair).Id;
        }

        public int Delete(Repair repair)
        {
            _bheDBContext.Repairs.Attach(repair);
            return _bheDBContext.Repairs.Remove(repair).Id;
        }

        public int Delete(int id)
        {
            var existing = _bheDBContext.Repairs.Find(id);
            if (existing != null)
            {
               _bheDBContext.Entry(existing).State = System.Data.Entity.EntityState.Deleted;
            }
            return id;
        }

        public IQueryable<Repair> Query()
        {
            return _bheDBContext.Repairs;
        }
    }
}