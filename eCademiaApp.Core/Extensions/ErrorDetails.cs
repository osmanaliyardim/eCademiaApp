using FluentValidation.Results;
using Newtonsoft.Json;

namespace eCademiaApp.Core.Extensions
{
    // Error detail entity for exception handling
    public class ErrorDetails
    {
        public string Message { get; set; }
        public string InnerMessage { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
