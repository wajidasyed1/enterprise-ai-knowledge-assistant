using KnowledgeAssistant.Domain.Documents;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeAssistant.Infrastructure.Persistence;

public sealed class KnowledgeAssistantDbContext : DbContext
{
    public KnowledgeAssistantDbContext(
        DbContextOptions<KnowledgeAssistantDbContext> options)
        : base(options)
    {
    }

    public DbSet<Document> Documents => Set<Document>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(KnowledgeAssistantDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}