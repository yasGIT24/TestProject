using System.Net;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

public class GitHubAppService
{
    private readonly string _jwt;
    private readonly long _installationId;

    public GitHubAppService(string jwt, long installationId)
    {
        _jwt = jwt;
        _installationId = installationId;
    }

    public async Task<string> GenerateInstallationToken()
    {
     
        ////With RestClient
        string GitHubApiUrl = "https://api.github.com";

        var restClient = new RestClient();
        var request = new RestRequest($"{GitHubApiUrl}/app/installations/{_installationId}/access_tokens", Method.Post);

        request.AddHeader("Authorization", $"Bearer {_jwt}");
        request.AddHeader("Accept", "application/vnd.github+json");

        var response = restClient.Execute(request);

        if (response.IsSuccessful)
        {
            // Parse the JSON response using Newtonsoft.Json
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

            // Extract the token field from the response
            string accessToken = jsonResponse.token;
            return accessToken;
        }
        else
        {
            throw new Exception($"Failed to create installation token: {response.StatusDescription}");
        }
    }

    public static async Task<int?> GetInstallationId(string jwtToken)
    {
        //var options = new RestClientOptions("https://localhost")
        //{
           
        //};
        var restClient = new RestClient();
        var request = new RestRequest("https://api.github.com/app/installations", Method.Get);
        
        request.AddHeader("Accept", "*/*");
        request.AddHeader("Authorization", $"Bearer {jwtToken}");
        
        RestResponse restResponse = await restClient.ExecuteAsync(request);

        if (!restResponse.IsSuccessStatusCode)
        {
            return null;
        }

        var json = JArray.Parse(restResponse.Content.ToString());

        if (json.Count > 0)
        {
            int installationId = json[0]["id"].Value<int>();
            Console.WriteLine($"Installation Id = {installationId}");
            return installationId;
        }
        Console.WriteLine("No installations found");
        return null;
    }
}