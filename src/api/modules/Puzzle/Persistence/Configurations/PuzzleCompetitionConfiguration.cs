using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMC.WebApi.Puzzle.Domain;

namespace TMC.WebApi.Puzzle.Persistence.Configurations;
internal sealed class PuzzleCompetitionConfiguration : IEntityTypeConfiguration<PuzzleCompetition>
{
    public void Configure(EntityTypeBuilder<PuzzleCompetition> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
    }
}
