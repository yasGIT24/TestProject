using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IAMTokenGeneration
{
    public class IAM
    {
        public static void MakeIAMTokenCall()
        {
            // Ensure TLS 1.2 is used
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var requestUrl = "https://genwizard-stagetest.accenture.com/atr-gateway/identity-management/api/v1/auth/token?useDeflate=false";

            try
            {
                using var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

                var requestBody = new
                {
                    username = "marketplace.integration",
                    password = "8f2hx5ap7U2LtWLX"
                };

                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, requestUrl)
                {
                    Content = content
                };

                var response = client.SendAsync(request).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static async Task GenerateTokenAsync()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (var client = new HttpClient())
            {

                var url = "https://genwizard-stagetest.accenture.com/atr-gateway/identity-management/api/v1/auth/token?useDeflate=false";

                var jsonBody = JsonConvert.SerializeObject(new
                {
                    username = "marketplace.integration",
                    password = "8f2hx5ap7U2LtWLX"
                });
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                client.DefaultRequestHeaders.Add("Cookie", "AUTH_SESSION=NmUzYmQxYzMtZDJjMi00MWRlLThkZGYtODdhYTNiMTc3NDUz");


                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content,

                };


                try
                {
                    //var response = client.PostAsync(url, content).GetAwaiter().GetResult();
                    Console.WriteLine("Sending request to: " + request.RequestUri);
                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                    Console.WriteLine("Status code: " + response.StatusCode);
                    response.EnsureSuccessStatusCode();
                    var responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    var tokenResponse = JsonConvert.DeserializeObject<string>(responseContent);
                    Console.WriteLine(tokenResponse);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to get token: {ex.Message}");

                }

                Console.ReadLine();
            }
        }


        public static async Task Token()
        {
            // Ensure TLS 1.2 is used
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            // Optional: Use HttpClientHandler to support proxy/auth/cert issues
            var handler = new HttpClientHandler
            {
                UseDefaultCredentials = true,
                Proxy = System.Net.WebRequest.DefaultWebProxy,
                UseProxy = true
            };

            using (var client = new HttpClient(handler))
            {
                var url = "https://genwizard-stagetest.accenture.com/atr-gateway/identity-management/api/v1/auth/token?useDeflate=false";

                var jsonBody = JsonConvert.SerializeObject(new
                {
                    username = "marketplace.integration",
                    password = "8f2hx5ap7U2LtWLX"
                });

                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                // Optional: Mimic Postman headers
                //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //request.Headers.Add("Cookie", "AUTH_SESSION=NmUzYmQxYzMtZDJjMi00MWRlLThkZGYtODdhYTNiMTc3NDUz"); // Only if needed
                
                try
                {
                    Console.WriteLine("Sending request to: " + url);
                    var response = await client.SendAsync(request);

                    Console.WriteLine("Status code: " + response.StatusCode);

                    response.EnsureSuccessStatusCode();

                    var responseContent = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("Response content:");
                    Console.WriteLine(responseContent);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"HTTP request error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex}");
                }

                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }
        }

    }
}

