// See https://aka.ms/new-console-template for more information
using System.Net;
using IAMTokenGeneration;


AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
{
    Console.WriteLine("🚨 Unhandled Exception: " + e.ExceptionObject);
    Console.ReadLine();
};

TaskScheduler.UnobservedTaskException += (sender, e) =>
{
    Console.WriteLine("🚨 Unobserved Task Exception: " + e.Exception);
    e.SetObserved();
    Console.ReadLine();
};

AppContext.SetSwitch("Switch.System.Net.DontEnableSystemDefaultTlsVersions", false);
System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

IAM.MakeIAMTokenCall();
//IAM.GenerateTokenAsync();
//IAM.Token();