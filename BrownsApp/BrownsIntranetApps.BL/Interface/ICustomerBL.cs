using BrownsIntranetApps.DTO;
using System.Collections.Generic;

namespace BrownsIntranetApps.BL.Interface
{
    public interface ICustomerBL
    {
        IEnumerable<CustomerDTO> GetAll();

        IEnumerable<CustomerHomeDTO> GetAllForHome();

        IEnumerable<CustomerListDTO> GetAllWithAddress();

        CustomerDTO Get(int customerId);
        CustomerDTO Add(CustomerDTO customer);

        int Update(CustomerDTO customer);

        int Delete(int id);
    }
}