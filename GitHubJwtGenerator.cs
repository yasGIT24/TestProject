using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

public class GitHubJwtGenerator
{
    private readonly string _clientId;
    private readonly RSA _rsa;

    public GitHubJwtGenerator(string clientId, string pemFileContent)
    {
        _clientId = clientId;
        _rsa = RSA.Create();
        _rsa.ImportFromPem(pemFileContent);
    }

    public string GenerateJwt()
    {
        var now = DateTime.UtcNow;
        var securityKey = new RsaSecurityKey(_rsa);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha256);

        var header = new JwtHeader(credentials);
        var payload = new JwtPayload(
            issuer: _clientId,
            audience: null,
            claims: null,
            notBefore: now,
            expires: now.AddMinutes(10), // JWTs for GitHub Apps expire after 10 minutes
            issuedAt: now
        );

        var token = new JwtSecurityToken(header, payload);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}