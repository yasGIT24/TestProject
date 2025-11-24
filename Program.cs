// See https://aka.ms/new-console-template for more information
using ErrorCodes;
using ErrorCodeClassLib;
using MyApp.Errors;
Console.WriteLine("Hello, World!");



List<ApplicationErrorMaster> errors = new()
{
    new ApplicationErrorMaster()
    {
        ErrorCode = "Error001",
        ErrorMessage = "ErrorMessageFor001",
        UseCase = "UseCase001"
    },
     new ApplicationErrorMaster()
    {
        ErrorCode = "Error002",
        ErrorMessage = "ErrorMessageFor002",
        UseCase = "UseCase002"
    },
     new ApplicationErrorMaster()
    {
        ErrorCode = "Error003",
        ErrorMessage = "ErrorMessageFor003",
        UseCase = "UseCase003"
    },
     new ApplicationErrorMaster()
    {
        ErrorCode = "Error004",
        ErrorMessage = "ErrorMessageFor004",
        UseCase = "UseCase004"
    },
      new ApplicationErrorMaster()
    {
        ErrorCode = "Error005",
        ErrorMessage = "ErrorMessageFor005",
        UseCase = "UseCase005"
    }
};
ErrorRegistry.RegisterErrors(errors);

ErrorCodes.Error error = ErrorRegistry.GetError(ErrorCodeRef.Error005);
Console.WriteLine(error.ErrorCode +"-"+error.ErrorMessage+"-"+error.UseCase);