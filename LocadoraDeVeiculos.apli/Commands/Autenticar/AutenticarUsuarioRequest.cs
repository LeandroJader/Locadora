using FluentResults;
using LocadoraDeVeiculos.apli.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.apli.Commands.Autenticar
{
    public record AutenticarUsuarioRequest(string UserName, string Password) : IRequest<Result<TokenResponse>>;
}
