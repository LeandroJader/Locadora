using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WebApi.Config
{
   public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        return app.UseExceptionHandler(builder =>
        {
            builder.Run(async httpContext =>
            {
                var gerenciadorExcecoes = httpContext.Features.Get<IExceptionHandlerFeature>();

                if (gerenciadorExcecoes is null) return;

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var objeto = new
                {
                    Sucesso = false,
                    Erros = new string[] { "Erro interno do servidor" }
                };

                var respostaJson = JsonSerializer.Serialize(objeto);

                await httpContext.Response.WriteAsync(respostaJson);
            });
        });
    }
}
