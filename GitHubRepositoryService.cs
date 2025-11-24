using LibGit2Sharp.Handlers;
using LibGit2Sharp;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;


public class GitHubRepositoryService
{
    private readonly string _installationToken;

    public GitHubRepositoryService(string installationToken)
    {
        _installationToken = installationToken;
    }

    public async Task CloneRepository(string repoUrl, string clonePath, [CallerMemberName] string callerMethod="", [CallerFilePath] string file="")
    {
        var options = new CloneOptions
        {
            BranchName = "master",
            FetchOptions = {
            CredentialsProvider = new CredentialsHandler((url, usernameFromUrl, types) =>
                new UsernamePasswordCredentials
                {
                    Username = "x-access-token",  // GitHub OAuth access token username -> x-access-token
                    Password = _installationToken  // The installation token we obtained earlier

                })
            }
        };

        try
        {
            // Clone the repository with the installation access token
            LibGit2Sharp.Repository.Clone(repoUrl, clonePath, options);
            Console.WriteLine("Repository cloned successfully.");
            StackTrace stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(2)?.GetMethod(); // Get caller's method info
            var method1 = stackTrace.GetFrame(1)?.GetMethod();
            var className = "";
            string callerClass = System.IO.Path.GetFileNameWithoutExtension(file);
            //if (caller.Contains("<"))
            //{
            //    caller = caller.Substring(1, caller.IndexOf(">") - 1);
            //}
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                MethodInfo methodName = type.GetMethod(callerMethod);
                if (methodName != null)
                    className= type.Name; // Return class name
            }
            

            //string className = method1?.DeclaringType?.Name ?? "";
            Console.WriteLine($"{callerClass} | {callerMethod}", "GetGitOAuthConfigByClientUIdAndRepoUrl Started", "Start -GetGitOAuthConfigByClientUIdAndRepoUrl");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error cloning repository: " + ex.Message);
        }
    }
}
