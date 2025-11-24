using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using System.Security.Cryptography;



namespace GitHubApp_Project
{
   
    public class GitHubAppAuthentication
    {
        private const string AppId = "1156085";  // Your GitHub App ID
        private const string PrivateKeyPath = "<path_to_your_pem_file>";  // Path to your PEM file
        private const string GitHubApiUrl = "https://api.github.com";

        public static string GenerateJwt()
        {
            // Load your private key (PEM file) content
            string privateKeyPem = File.ReadAllText(PrivateKeyPath);

            // Convert PEM to RSA
            var rsa = PemToRsa(privateKeyPem);

            // Create the JWT header and claims
            var jwt = JwtBuilder.Create()
                .WithAlgorithm(new RS256Algorithm(rsa))  // Use RS256 algorithm
                .AddClaim("iat", DateTimeOffset.UtcNow.ToUnixTimeSeconds())  // Issued at time
                .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds())  // Expiration time (10 minutes)
                .AddClaim("iss", AppId)  // GitHub App ID as the issuer
                .ToString();

            return jwt;
        }

        private static RSA PemToRsa(string pem)
        {
            var rsa = RSA.Create();
            var keyBytes = Convert.FromBase64String(pem);
            rsa.ImportRSAPrivateKey(keyBytes, out _);
            return rsa;
        }

        public static void Main()
        {
            // Generate the JWT
            var jwt = GenerateJwt();
            Console.WriteLine("Generated JWT: " + jwt);
        }
    }

}
