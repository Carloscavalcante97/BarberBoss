using System.Net;

namespace BarberBoss.Exception.ExceptionBase
{
    public class ErrorOnValidationException : BarberBossException
    {
        public readonly List<string> _errors;
        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public ErrorOnValidationException(List<string> errorMessage) : base(string.Empty)
        {
            _errors = errorMessage;
        }

        public override List<string> GetErrors()
        {
            return _errors;
        }
    }
}
