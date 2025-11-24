using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WebApi.Config
{
    public static bool AutoMigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<OrganizaMedDbContext>();

        var migracaoConcluida = Migrador.AtualizarBancoDados(dbContext);

        return migracaoConcluida;
    }
}
