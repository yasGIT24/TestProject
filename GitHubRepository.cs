using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Octokit;
using System.IO;
using RestSharp;
using LibGit2Sharp;
using Newtonsoft.Json.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using System.Net;

namespace GitHubApp_Project
{
    public class GitHubRepository
    {
        private static readonly string githubUsername = "yasGIT24";
        private static readonly string repoName = "OnlineBanking";
        private static readonly string filePath = @"C:\Users\yasmin.shahul.hameed\Downloads\OnlinebkApr25\OnlinebkApr23\Online_banking\BalanceEnquiry.java";  // ZIP file path
        private static readonly string githubToken = @"PAT";  // Personal Access Token
        private static readonly string branch = "main"; // Change to your branch if different

        private static readonly string apiUrl = "https://api.github.com/user/repos";

        public static async Task UploadFileToGitHub()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File not found at {filePath}");
                return;
            }
            string fileName = Path.GetFileName(filePath);
            string fileUrl = $"https://api.github.com/repos/{githubUsername}/{repoName}/contents/{fileName}";


            byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
            string base64Content = Convert.ToBase64String(fileBytes);

            var fileData = new
            {
                message = $"Upload {fileName}",
                content = base64Content,
                branch = branch
            };

            string jsonContent = JsonSerializer.Serialize(fileData);

            //using HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("CSharpApp", "1.0"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", githubToken);

            var client = new RestClient(fileUrl);
            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {githubToken}");
            //request.AddHeader("User-Agent", "RestSharpClient");
            request.AddJsonBody(fileData);
            request.Method = Method.Put;

            var response = await client.ExecuteAsync(request);

            //var response = await client.PutAsync(fileUrl, new StringContent(jsonContent, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("File uploaded successfully!");
            }
            else
            {
                // string errorResponse = await response.Content.ReadAsStringAsync();
                string errorResponse = response.Content;
                Console.WriteLine($"Failed to upload file: {response.StatusCode}\n{errorResponse}");
            }
        }

        public static (string, string) ReturnTwoValues()
        {
            string first = "First";
            string second = "Second";
            return (first, second);
        }
    }
}