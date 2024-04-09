using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SpacecapsCase.Domain.Constants;
using SpacecapsCase.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacecapsCase.Domain.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(UsuarioCadastradoException ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");

                context.Response.StatusCode = StatusCodes.Status409Conflict;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync("{\"message\": \"" + Mensagens.USUARIO_JA_CADASTRADO + "\"}");
            }
            catch(UsuarioSemPermissaoException ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");

                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync("{\"message\": \"" + Mensagens.USUARIO_SEM_PERMISSAO + "\"}");
            }
            catch(UsuarioNaoCadastradoException ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync("{\"message\": \"" + Mensagens.USUARIO_NAO_CADASTRADO + "\"}");
            }
            catch (LoginIncorretoException ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync("{\"message\": \"" + Mensagens.SENHA_INCORRETA + "\"}");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");

                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync("{\"message\": \"" + Mensagens.USUARIO_NAO_CADASTRADO + "\"}");
            }
            catch (TarefaNaoEncontradaException ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");

                context.Response.StatusCode = StatusCodes.Status204NoContent;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync("{\"message\": \"" + Mensagens.TAREFA_NAO_ENCONTRADA + "\"}");
            }
            catch (NivelInvalidadoUsuarioException ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");

                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync("{\"message\": \"" + Mensagens.NIVEL_USUARIO_INVALIDO + "\"}");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync("{\"message\": \"An unexpected error occurred.\"}");
            } 
        }
    }
}