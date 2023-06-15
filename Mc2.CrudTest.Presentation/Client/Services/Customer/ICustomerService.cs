namespace Mc2.CrudTest.Presentation.Client.Services.Customer;

using Mc2.CrudTest.Presentation.Client.Dtos.Customer;
using System.Threading.Tasks;


public interface ICustomerService
{
    Task<AddCustomerResponseDto> AddCustomer(AddCustomerRequestDto request);
    Task<GetCustomersByPageResponseDto> GetAllCustomers();
    Task<bool> DeleteCustomer(ulong customerId);
    Task<UpdateDto> UpdateCustomer(UpdateDto request);
}