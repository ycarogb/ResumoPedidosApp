using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Domain.Dtos;
using ResumoPedidos.Services.Autenticacao;

namespace ResumoPedidos.Controllers.Autenticacao;

[ApiController]
[Route("authentication")]
public class AutenticacaoController
{
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<dynamic>> AuthenticaticateAsync([FromBody] UsuarioDto usuario)
    {
        /*Obtem o usuário*/
        var user = UsuarioRepository.Get(usuario.Username, usuario.Password);
        
        /*Verifica se o usuário existe*/
        if (user == null)
        {
            throw new AuthenticationException("Usuário ou senha inválido!");
        }
        
        /*Gera o Token*/
        var token = TokenService.GenerateToken(user);

        user.Password = "";

        return new
        {
            token,
            user
        };
    }
}