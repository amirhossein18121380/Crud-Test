using Mc2.CrudTest.Presentation.Server.Customers.Exceptions;
using Mc2.CrudTest.Presentation.Server.Customers.Features.UpdateCustomer;
using Mc2.CrudTest.Presentation.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Test;
public class UpdateCustomerHandlerTests
{
    private readonly DbContextOptions<CustomerDbContext> _options;

    public UpdateCustomerHandlerTests()
    {
        // Set up an in-memory database for testing
        _options = new DbContextOptionsBuilder<CustomerDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }


    //[Fact]
    //public async Task Handle_ValidRequest_CustomerUpdated()
    //{
    //    // Arrange
    //    ulong customerId = 8314617814023208690;
    //    var request = new UpdateCustomer(
    //        Id: customerId,
    //        FirstName: "John",
    //        Lastname: "Doe",
    //        DateOfBirth: new DateTime(1990, 1, 1),
    //        PhoneNumber: "1234567890",
    //        Email: "john.doe@example.com",
    //        BankAccountNumber: "123456789"
    //    );

    //    using (var context = new CustomerDbContext(_options))
    //    {
    //        var customer = Customer.Create(
    //            id: customerId,
    //            firstName: "Jane",
    //            lastName: "Smith",
    //            dateOfBirth: new DateTime(1980, 1, 1),
    //            phoneNumber: "9876543210",
    //            email: "jane.smith@example.com",
    //            bankAccountNumber: "987654321"
    //        );

    //        context.Customers.Add(customer);
    //        context.SaveChanges();
    //    }

    //    using (var context = new CustomerDbContext(_options))
    //    {
    //        var handler = new UpdateCustomerHandler(context);

    //        // Act
    //        var result = await handler.Handle(request, CancellationToken.None);

    //        // Assert
    //        Assert.NotNull(result);
    //        Assert.Equal(request.Id, result.Customer.Id);
    //        Assert.Equal(request.FirstName, result.Customer.FirstName);
    //        Assert.Equal(request.Lastname, result.Customer.Lastname);
    //        Assert.Equal(request.DateOfBirth, result.Customer.DateOfBirth);
    //        Assert.Equal(request.PhoneNumber, result.Customer.PhoneNumber);
    //        Assert.Equal(request.Email, result.Customer.Email);
    //        Assert.Equal(request.BankAccountNumber, result.Customer.BankAccountNumber);
    //    }
    //}

    [Fact]
    public async Task Handle_InvalidId_ThrowsCustomerNotFoundException()
    {
        // Arrange
        var request = new UpdateCustomer(
            Id: 8314617814023208690,
            FirstName: "John",
            Lastname: "Doe",
            DateOfBirth: new DateTime(1990, 1, 1),
            PhoneNumber: "1234567890",
            Email: "john.doe@example.com",
            BankAccountNumber: "123456789"
        );

        using (var context = new CustomerDbContext(_options))
        {
            var handler = new UpdateCustomerHandler(context);

            // Act & Assert
            await Assert.ThrowsAsync<CustomerNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }

    //[Fact]
    //public async Task Handle_DuplicateEmail_ThrowsEmailAlreadyExistException()
    //{
    //    // Arrange
    //    ulong customerId = 8314617814023208690;
    //    var request = new UpdateCustomer(
    //        Id: customerId,
    //        FirstName: "John",
    //        Lastname: "Doe",
    //        DateOfBirth: new DateTime(1990, 1, 1),
    //        PhoneNumber: "1234567890",
    //        Email: "john.doe@example.com",
    //        BankAccountNumber: "123456789"
    //    );

    //    using (var context = new CustomerDbContext(_options))
    //    {
    //        var existingCustomer = Customer.Create(
    //            id: customerId,
    //            firstName: "Jane",
    //            lastName: "Smith",
    //            dateOfBirth: new DateTime(1980, 1, 1),
    //            phoneNumber: "9876543210",
    //            email: "john.doe@example.com",
    //            bankAccountNumber: "987654321"
    //        );

    //        context.Customers.Add(existingCustomer);
    //        context.SaveChanges();
    //    }

    //    using (var context = new CustomerDbContext(_options))
    //    {
    //        var handler = new UpdateCustomerHandler(context);

    //        // Act & Assert
    //        await Assert.ThrowsAsync<EmailAlreadyExistException>(
    //            async () => await handler.Handle(request, CancellationToken.None)
    //        );
    //    }
    //}
}
