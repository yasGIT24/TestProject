using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ErrorCodes
{
    public static class ErrorRegistry
    {
        private static readonly Dictionary<string, Error> _errors = new();
        public static Dictionary<string, Error> Errors { get { return _errors; } }
        public static void RegisterErrors(IEnumerable<ApplicationErrorMaster> errorList)
        {
            _errors.Clear();

            foreach (var error in errorList)
            {
                _errors[error.ErrorCode] = new Error
                {
                    ErrorCode = error.ErrorCode,
                    ErrorMessage = error.ErrorMessage,
                    UseCase = error.UseCase
                };
            }
        }

        public static Error GetError(string errorCode)
        {
            return _errors.TryGetValue(errorCode, out var error)
                ? error
                : new Error { ErrorCode = string.Empty, ErrorMessage = "Unknown error.", UseCase = "Unknown" };
        }


        public static IEnumerable<Error> GetErrors()
        {
            return Errors.Values;
        }
    }
    public class Error
    {
        public required string ErrorCode { get; set; }
        public required string ErrorMessage { get; set; }
        public string? UseCase { get; set; }
    }

    public class ApplicationErrorMaster
    {
        public Guid ApplicationErrorMasterUId { get; set; }
        public required string ErrorCode { get; set; }
        public required string ErrorMessage { get; set; }
        public string? UseCase { get; set; }
    }
}