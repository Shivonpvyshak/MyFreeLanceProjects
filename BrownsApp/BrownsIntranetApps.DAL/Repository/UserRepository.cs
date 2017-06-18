using BrownsIntranetApps.DAL.Interface;
using BrownsIntranetApps.Entity.SQL;

namespace BrownsIntranetApps.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private BrownsAppDBEntities1 _bheDBContext;

        public UserRepository(BrownsAppDBEntities1 bheDBContext)
        {
            _bheDBContext = bheDBContext;
        }
    }
}