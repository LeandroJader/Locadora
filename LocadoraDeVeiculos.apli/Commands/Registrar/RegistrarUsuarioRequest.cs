using FluentResults;
using LocadoraDeVeiculos.apli.DTOs;
using MediatR;

namespace LocadoraDeVeiculos.apli.Commands.Registrar;

public record RegistrarUsuarioRequest(string UserName, string Email, string Password)
    : IRequest<Result<TokenResponse>>;