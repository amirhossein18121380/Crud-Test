using FluentAssertions;
using FluentValidation.TestHelper;
using Mc2.CrudTest.Presentation.Server.Customers.Features.AddCustomer;
using Mc2.CrudTest.Presentation.Server.Customers.Features.DeleteCustomer;
using Mc2.CrudTest.Presentation.Server.Customers.Features.UpdateCustomer;
using Test.Common;
using Test.Fakes;

namespace Test;

[Collection(nameof(UnitTestFixture))]
public class CustomerTest
{
    private readonly UnitTestFixture _fixture;
    private readonly AddCustomerHandler _addCustomerHandler;
    private readonly UpdateCustomerHandler _updateCustomerHandler;
    private readonly DeleteCustomerHandler _deleteCustomerHandler;

    public Task<AddCustomerResult> Act(AddCustomer command, CancellationToken cancellationToken) =>
        _addCustomerHandler.Handle(command, cancellationToken);

    public Task<UpdateCustomerResult> Update(UpdateCustomer command, CancellationToken cancellationToken) =>
        _updateCustomerHandler.Handle(command, cancellationToken);

    public Task<bool> Delete(DeleteCustomer command, CancellationToken cancellationToken) =>
        _deleteCustomerHandler.Handle(command, cancellationToken);


    public CustomerTest(UnitTestFixture fixture)
    {
        _fixture = fixture;
        _addCustomerHandler = new AddCustomerHandler(fixture.DbContext);
        _updateCustomerHandler = new UpdateCustomerHandler(fixture.DbContext);
        _deleteCustomerHandler = new DeleteCustomerHandler(fixture.DbContext);
    }

    [Fact]
    public void is_valid_should_be_false_when_add_validation_parameters_is_invalid()
    {
        // Arrange
        var command = new FakeValidateAddCustomer().Generate();
        var validator = new AddCustomerValidator();

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
        result.ShouldHaveValidationErrorFor(x => x.Lastname);
        result.ShouldHaveValidationErrorFor(x => x.PhoneNumber);
        result.ShouldHaveValidationErrorFor(x => x.Email);
        result.ShouldHaveValidationErrorFor(x => x.BankAccountNumber);
    }

    [Fact]
    public async Task handler_with_valid_command_should_create_product_and_return_valid_product_id()
    {
        // Arrange
        var command = new FakeAddCustomerCommand().Generate();

        // Act
        var response = await Act(command, CancellationToken.None);

        // Assert
        var entity = await _fixture.DbContext.Customers.FindAsync(response.Id);

        entity?.Should().NotBeNull();
        entity?.Id.Should().Be(response.Id);
        entity?.Id.Should().Be(command.Id);
    }


    //[Fact]
    //public async Task handler_with_valid_command_should_update_customer_and_return_valid()
    //{
    //    // Arrange

    //    var command = new FakeUpdateCustomerCommand().Generate();
    //    // Act
    //    var response = await Update(command, CancellationToken.None);

    //    response.Should().NotBeNull();
    //    response?.Customer?.FirstName?.Equals("Updated");
    //}
}