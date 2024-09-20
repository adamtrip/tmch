using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;

namespace TMC.WebApi.Puzzle.Domain;

public class PuzzleCompetition : AuditableEntity, IAggregateRoot
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
