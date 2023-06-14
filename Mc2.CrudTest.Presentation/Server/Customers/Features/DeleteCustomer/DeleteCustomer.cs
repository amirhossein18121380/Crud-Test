﻿using Mc2.CrudTest.Presentation.Shared.Core.CQRS;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.DeleteCustomer;

public record DeleteCustomer(Guid Id) : ICommand<bool>
{ }