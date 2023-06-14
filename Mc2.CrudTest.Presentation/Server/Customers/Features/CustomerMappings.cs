using AutoMapper;
using Mc2.CrudTest.Presentation.Server.Customers.Features.AddCustomer;
using Mc2.CrudTest.Presentation.Server.Customers.Features.GettingAllCustomersByPage;
using Mc2.CrudTest.Presentation.Server.Customers.Features.UpdateCustomer;
using Mc2.CrudTest.Presentation.Server.Customers.Models;
using Mc2.CrudTest.Presentation.Shared.Core.Pagination;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features;


public class CustomerMappings : Profile
{
    public CustomerMappings()
    {
        #region Adds
        CreateMap<AddCustomerRequestDto, AddCustomer.AddCustomer>();
        CreateMap<AddCustomer.AddCustomer, Customer>();
        CreateMap<Customer, AddCustomerResult>();
        #endregion

        #region Gets
        CreateMap<GetCustomersByPageResult, GetCustomersByPageResponseDto>();
        CreateMap<GetCustomersByPageRequestDto, GetCustomersByPage>();

        CreateMap<Customer, CustomerDto>()
            .ConstructUsing(x =>
                new CustomerDto(x.Id, x.FirstName, x.Lastname, x.DateOfBirth, x.PhoneNumber, x.Email, x.BankAccountNumber));

        CreateMap<PageList<Customer>, PageList<CustomerDto>>();
        #endregion

        #region Updates
        CreateMap<UpdateCustomerRequestDto, UpdateCustomer.UpdateCustomer>();
        #endregion
    }
}
