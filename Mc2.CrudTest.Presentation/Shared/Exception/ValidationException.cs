namespace Mc2.CrudTest.Presentation.Shared.Exception
{
    public class ValidationException : CustomException
    {
        public ValidationException(string message, int? code = null) : base(message, code: code)
        {
        }
    }
}
