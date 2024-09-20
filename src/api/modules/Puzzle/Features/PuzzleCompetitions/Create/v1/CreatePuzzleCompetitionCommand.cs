using Ardalis.Result;
using MediatR;

namespace TMC.WebApi.Puzzle.Features.PuzzleCompetitions.Create.v1;

public record CreatePuzzleCompetitionCommand() : IRequest<Result>;
