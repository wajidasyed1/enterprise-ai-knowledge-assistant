using KnowledgeAssistant.Domain.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeAssistant.Infrastructure.Persistence.Configurations;

public sealed class DocumentConfiguration :
    IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.ToTable("Documents");

        builder.HasKey(document => document.Id);

        builder.Property(document => document.FileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(document => document.ContentType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(document => document.FileSizeBytes)
            .IsRequired();

        builder.Property(document => document.UploadedBy)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(document => document.Status)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(document => document.UploadedAtUtc)
            .IsRequired();

        builder.Property(document => document.ProcessedAtUtc);

        builder.Property(document => document.FailureReason)
            .HasMaxLength(1_000);

        builder.HasIndex(document => document.FileName);

        builder.HasIndex(document => document.UploadedAtUtc);
    }
}