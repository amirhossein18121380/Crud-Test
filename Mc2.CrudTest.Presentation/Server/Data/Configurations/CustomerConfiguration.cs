using Mc2.CrudTest.Presentation.Server.Customers.Models;

namespace Mc2.CrudTest.Presentation.Server.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {

        builder.HasKey(u => u.Id);
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Lastname).IsRequired().HasMaxLength(50);
        builder.Property(u => u.DateOfBirth).IsRequired();
        builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(13);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
        builder.Property(u => u.BankAccountNumber).IsRequired().HasMaxLength(50);
    }
}