using KnowledgeAssistant.Domain.Documents;

namespace KnowledgeAssistant.UnitTests.Documents;

public sealed class DocumentTests
{
    [Fact]
    public void Constructor_creates_uploaded_document()
    {
        var document = new Document(
            "employee-handbook.pdf",
            "application/pdf",
            250_000,
            "wajid");

        Assert.NotEqual(Guid.Empty, document.Id);
        Assert.Equal("employee-handbook.pdf", document.FileName);
        Assert.Equal("application/pdf", document.ContentType);
        Assert.Equal(250_000, document.FileSizeBytes);
        Assert.Equal("wajid", document.UploadedBy);
        Assert.Equal(DocumentStatus.Uploaded, document.Status);
        Assert.Null(document.ProcessedAtUtc);
        Assert.Null(document.FailureReason);
    }

    [Fact]
    public void MarkAsProcessing_changes_status()
    {
        var document = CreateDocument();

        document.MarkAsProcessing();

        Assert.Equal(DocumentStatus.Processing, document.Status);
    }

    [Fact]
    public void MarkAsIndexed_sets_processed_time()
    {
        var document = CreateDocument();

        document.MarkAsIndexed();

        Assert.Equal(DocumentStatus.Indexed, document.Status);
        Assert.NotNull(document.ProcessedAtUtc);
        Assert.Null(document.FailureReason);
    }

    [Fact]
    public void MarkAsFailed_stores_failure_reason()
    {
        var document = CreateDocument();

        document.MarkAsFailed("Unable to extract text.");

        Assert.Equal(DocumentStatus.Failed, document.Status);
        Assert.Equal(
            "Unable to extract text.",
            document.FailureReason);
        Assert.NotNull(document.ProcessedAtUtc);
    }

    [Fact]
    public void Constructor_rejects_empty_file_name()
    {
        Assert.Throws<ArgumentException>(() =>
            new Document(
                "",
                "application/pdf",
                100,
                "wajid"));
    }

    private static Document CreateDocument()
    {
        return new Document(
            "policy.pdf",
            "application/pdf",
            100_000,
            "wajid");
    }
}