using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ResumoPedidos.Domain.Administracao;

namespace ResumoPedidos.Services.Autenticacao;

public static class TokenService
{
    public static string GenerateToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim(ClaimTypes.Role, usuario.Role),
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            /*Representa a chave de criptografia e os algoritmos de segurança usados para gerar uma assinatura digital*/
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        /*WriteToken necessário para transformar o token do type SecurityToken em string*/
        return tokenHandler.WriteToken(token);
    }
}