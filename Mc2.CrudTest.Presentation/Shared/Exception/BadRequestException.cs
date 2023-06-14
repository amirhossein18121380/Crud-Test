namespace Mc2.CrudTest.Presentation.Shared.Exception
{
    public class BadRequestException : CustomException
    {
        public BadRequestException(string message, int? code = null) : base(message, code: code)
        {

        }
    }
}
