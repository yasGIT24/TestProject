////
////Clone Repo using Github App
////var appId = "1156085";

//// Inputs//
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using Octokit;
//using System.Diagnostics;
//using System.Text;

//var clientID = "ClientID";
//string PrivateKeyPath = @"C:\\Users\yasmin.shahul.hameed\Downloads\yasgithubapp.2025-02-24.private-key.pem";
//var owner = "yasGIT24";
//var repoName = "SampleApplicationForDeployment";
//var repoUrl = $"https://github.com/{owner}/{repoName}";
//string pat = "pat";
//Console.WriteLine("PAtToken = " + Convert.ToBase64String(Encoding.UTF8.GetBytes(pat)));

////"https://github.com/yasGIT24/SampleApplicationForDeployment"
//string pemFileContent = File.ReadAllText(PrivateKeyPath);
//var clonePath = "C://test/GitHubApptest/" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "");
//string base64EncodedKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(pemFileContent));

//Console.WriteLine("Base64 Encoded Private Key:");
//Console.WriteLine(base64EncodedKey);

//// Step 1: Generate JWT
//var jwtGenerator = new GitHubJwtGenerator(clientID, pemFileContent);
//var jwt = jwtGenerator.GenerateJwt();
//Console.WriteLine($"Jwt = {jwt}");
//var installationId = (int)await GitHubAppService.GetInstallationId(jwt);

//// Step 2: Generate Installation Access Token
//var appService = new GitHubAppService(jwt, installationId);
//var installationToken = await appService.GenerateInstallationToken();
//Console.WriteLine($"Installation Token = {installationToken}");

//// Step 3: Use the Installation Access Token to clone the repository
//var repoService = new GitHubRepositoryService(installationToken);

//await repoService.CloneRepository(repoUrl, clonePath);

//var bytes = Encoding.UTF8.GetBytes(installationToken);
//Console.WriteLine($"Encoded Token ={Convert.ToBase64String(bytes)}");
//Console.WriteLine($"Decoded Token = {Encoding.UTF8.GetString(bytes)}");

////var pwd = "Vm9Yc3N2WlYyekpIU3M0WXh4NWZPWkxrZ2JvUUptZWtINzk1dm9ydmhvaHpHUGFJZDVPZjNXRWp3VlE9";
//////Decoded Token = VoXssvZV2zJHSs4Yxx5fOZLkgboQJmekH795vorvhohzGPaId5Of3WEjwVQ=
////Console.WriteLine($"Decoded Token = {Encoding.UTF8.GetString(Convert.FromBase64String(pwd))}");
////Console.WriteLine($"Decoded = {Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedKey))}");
////string pat = "pat";
//Console.WriteLine("PAtToken = "+ Convert.ToBase64String(Encoding.UTF8.GetBytes(pat)));
//List<RepoInputs> repoInputsList = new List<RepoInputs>()
//{
//    new RepoInputs
//    {
//        repoName="onlinebanking21",
//        repoUrl="https://git-codecommit.us-east-1.amazonaws.com/v1/repos/onlinebanking21",
//        repoUsername="uname=",
//    repoPassword = "pwd",
//    branchName = "master",
//authenticationType = "OAuth2"
//    },
//    new RepoInputs
//    {
//          repoName="OnlineFood",
//        repoUrl="https://git-codecommit.us-east-1.amazonaws.com/v1/repos/OnlineFood",
//        repoUsername="uname",
//    repoPassword = "pwd=",
//    branchName = "master",
//authenticationType = "OAuth2"
//    }
//};

////var c = new RepoOAuthConfig
////{
////    RepoUrl = "https://git-codecommit.us-east-1.amazonaws.com"
////};

////var configs = repoInputsList.Where(x =>new Uri(x.repoUrl.ToLower()).GetLeftPart(UriPartial.Path) == new Uri(c.RepoUrl.ToLower().Trim()).GetLeftPart(UriPartial.Path)).Select(e=> e.repoUrl).ToList();
//////.Distinct()
////// .ToList();

////var can = repoInputsList.Select(e=> e.repoUrl.TrimEnd('/').Contains(c.RepoUrl.TrimEnd('/')));
////var ur = repoInputsList.Any(url => new Uri(url.repoUrl).GetLeftPart(UriPartial.Path) == new Uri(c.RepoUrl).GetLeftPart(UriPartial.Path));
////Console.WriteLine("Configs"+configs.Count.ToString() + "-"+ can.ToList().Count+ "-"+ur);

////dynamic payLoad = JsonConvert.DeserializeObject<AddrepoRequest>(@"{""templateName"":""Global Pattern"",""SourceCategory"":1,""useCases"":[""Explanation"",""Backlog(Feature/UserStory)""],""PatternUId"":""7e45b3bc-a0be-4b2b-ac50-1f46fec0bc25"",""repoDetails"":[{""repoName"":""onlinebanking21"",""repoUrl"":""https://git-codecommit.us-east-1.amazonaws.com/v1/repos/onlinebanking21"",""repoUsername"":""QWtzaGF5X0lBTS1hdC0zMTc3NTY0ODkwOTQ="",""repoPassword"":""Vm9Yc3N2WlYyekpIU3M0WXh4NWZPWkxrZ2JvUUptZWtINzk1dm9ydmhvaHpHUGFJZDVPZjNXRWp3VlE9"",""branchName"":""master""}],""appName"":""Onlinebank"", ""AuthenticationType"":""OAuth2""}");
////Action<AddrepoRequest> del = x =>
////{
////    x.repoDetails.ForEach(a => a.repoUsername = "x-access-token");
////    x.repoDetails.ForEach(a => a.repoPassword = "installationAccessTokenEncoded");
////};
////del(payLoad);
////Console.WriteLine($"Current Payload uname and pwd = {payLoad.repoDetails.First().repoUsername}");

////public class AddrepoRequest
////{
////    public string templateName { get; set; }
////    public int SourceCategory { get; set; }
////    public List<string> useCases { get; set; }
////    public string PatternUId { get; set; }
////    public string appName { get; set; }
////    public List<RepoInputs> repoDetails { get; set; }
////    public string AuthenticationType { get; set; }

////}

//public class RepoInputs
//{
//    public string repoName { get; set; }
//    public string repoUrl { get; set; }
//    public string repoUsername { get; set; }
//    public string repoPassword { get; set; }
//    public string branchName { get; set; }
//    public string authenticationType { get; set; }
//}

//public class RepoOAuthConfig
//{
//    public Guid RepoOAuthConfigId { get; set; }
//    public Guid ClientUId { get; set; }
//    public string RepoUrl { get; set; }
//    public string ClientId { get; set; }
//    public string Key { get; set; }
//    public string GitHubApiUrl { get; set; }
//    public string GitHubAppInstallationsUrl { get; set; }
//    public DateTime CreatedOn { get; set; }
//    public string KeyType { get; set; }
//}


//(string fris, string two)= GitHubRepository.ReturnTwoValues();
//Console.WriteLine("First = "+ fris+" Second = "+ two);


