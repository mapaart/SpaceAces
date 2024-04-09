using SpacecapsCase.Application.Services;
using SpacecapsCase.Domain.Constants;
using SpacecapsCase.Domain.Dto;
using SpacecapsCase.Domain.Exception;
using SpacecapsCase.Domain.Interfaces;
using SpacecapsCase.Infrastructure.Data.Context;
using SpacecapsCase.Infrastructure.Data.Repositories;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace SpacecapsCase.Domain.UseCases
{
    public class LoginUseCaseImpl : ILoginUseCase
    {
        private readonly IConfiguration _configuration;

        public LoginUseCaseImpl(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        UsuarioService CreateService()
        {
            DatabaseContext db = new DatabaseContext();
            UsuarioRepository repository = new UsuarioRepository(db);
            UsuarioService service = new UsuarioService(repository);
            return service;
        }
        public Task<string> RealizarLogin(Login login)
        {
            var service = CreateService();
            var usuario = service.GetByName(login.usuario) ?? throw new UsuarioNaoCadastradoException(Mensagens.USUARIO_NAO_CADASTRADO);
            var autenticacao = BCrypt.Net.BCrypt.Verify(login.senha, usuario.Senha);
            if (autenticacao)
            {
                return Task.FromResult(GerarToken(usuario.Nome));
            }
            else
            {
                throw new LoginIncorretoException(Mensagens.SENHA_INCORRETA);
            }
        }

        public string GerarToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var issuer = _configuration["Jwt:Issuer"];
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["Jwt:ExpirationInMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuer
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

