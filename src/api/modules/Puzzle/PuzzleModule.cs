using Carter;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using TMC.WebApi.Puzzle.Domain;
using TMC.WebApi.Puzzle.Features.PuzzleCompetitions.Create.v1;
using TMC.WebApi.Puzzle.Persistence;

namespace TMC.WebApi.Puzzle;

public static class PuzzleModule
{
    public class Endpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var puzzleGroup = app.MapGroup("puzzle").WithTags("puzzle");
            puzzleGroup.MapPuzzleCompetitionECreationEndpoint();
        }
    }
    public static WebApplicationBuilder RegisterPuzzleServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Services.BindDbContext<PuzzleDbContext>();
        builder.Services.AddScoped<IDbInitializer, PuzzleDbInitializer>();
        builder.Services.AddKeyedScoped<IRepository<PuzzleCompetition>, PuzzleRepository<PuzzleCompetition>>("puzzle");
        builder.Services.AddKeyedScoped<IReadRepository<PuzzleCompetition>, PuzzleRepository<PuzzleCompetition>>("puzzle");
        return builder;
    }
    public static WebApplication UsePuzzleModule(this WebApplication app)
    {
        return app;
    }
}
