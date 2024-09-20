using Finbuckle.MultiTenant.Abstractions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using FSH.Framework.Infrastructure.Tenant;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TMC.WebApi.Puzzle.Domain;

namespace TMC.WebApi.Puzzle.Persistence;

public sealed class PuzzleDbContext : FshDbContext
{
    public PuzzleDbContext(IMultiTenantContextAccessor<FshTenantInfo> multiTenantContextAccessor,
        DbContextOptions<PuzzleDbContext> options, IPublisher publisher, IOptions<DatabaseOptions> settings)
        : base(multiTenantContextAccessor, options, publisher, settings)
    {
    }

    public DbSet<PuzzleCompetition> PuzzleCompetitions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PuzzleDbContext).Assembly);
        modelBuilder.HasDefaultSchema(SchemaNames.Puzzle);
    }
}
