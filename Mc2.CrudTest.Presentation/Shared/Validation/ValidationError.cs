namespace Mc2.CrudTest.Presentation.Shared.Validation
{
    public class ValidationError
    {
        public string Field { get; }

        public string Message { get; }

        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }
}