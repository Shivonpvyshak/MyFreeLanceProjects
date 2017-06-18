using BrownsIntranetApps.DAL.Interface;
using BrownsIntranetApps.Entity.SQL;

namespace BrownsIntranetApps.DAL.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private BrownsAppDBEntities1 _bheDBContext;

        public CompanyRepository(BrownsAppDBEntities1 bheDBContext)
        {
            _bheDBContext = bheDBContext;
        }

        public void Add(Company company)
        {
            _bheDBContext.Companies.Add(company);
        }
    }
}