using Ardalis.Result;
using Asp.Versioning;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace TMC.WebApi.Puzzle.Features.PuzzleCompetitions.Create.v1;

public static class CreatePuzzleCompetitionEndpoint
{
    internal static RouteHandlerBuilder MapPuzzleCompetitionECreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/", async (CreatePuzzleCompetitionCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.CreatedAtRoute(nameof(CreatePuzzleCompetitionEndpoint), response);
            })
            .WithName(nameof(CreatePuzzleCompetitionEndpoint))
            .WithSummary("Creates a puzzle competition")
            .WithDescription("Creates a puzzle competition")
            .RequirePermission("Permissions.PuzzleCompetitions.Create")
            .MapToApiVersion(new ApiVersion(1, 0));

    }
}
