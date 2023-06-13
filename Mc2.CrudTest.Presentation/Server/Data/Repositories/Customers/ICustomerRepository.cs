using Mc2.CrudTest.Presentation.Server.Customers.Models;
using Mc2.CrudTest.Presentation.Server.Data.Repositories.Interfaces;

namespace Mc2.CrudTest.Presentation.Server.Data.Repositories.Customers
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
