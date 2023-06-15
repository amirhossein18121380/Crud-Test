namespace Mc2.CrudTest.Presentation.Client.Models.Customer
{
    public class Customer
    {
        public ulong Id { get; set; }
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? BankAccountNumber { get; set; }
    }
}
