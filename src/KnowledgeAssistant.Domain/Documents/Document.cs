namespace KnowledgeAssistant.Domain.Documents;

public sealed class Document
{
    private Document()
    {
    }

    public Document(
        string fileName,
        string contentType,
        long fileSizeBytes,
        string uploadedBy)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentException(
                "File name is required.",
                nameof(fileName));
        }

        if (string.IsNullOrWhiteSpace(contentType))
        {
            throw new ArgumentException(
                "Content type is required.",
                nameof(contentType));
        }

        if (fileSizeBytes <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(fileSizeBytes),
                "File size must be greater than zero.");
        }

        if (string.IsNullOrWhiteSpace(uploadedBy))
        {
            throw new ArgumentException(
                "Uploaded by is required.",
                nameof(uploadedBy));
        }

        Id = Guid.NewGuid();
        FileName = fileName.Trim();
        ContentType = contentType.Trim();
        FileSizeBytes = fileSizeBytes;
        UploadedBy = uploadedBy.Trim();
        Status = DocumentStatus.Uploaded;
        UploadedAtUtc = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }

    public string FileName { get; private set; } = string.Empty;

    public string ContentType { get; private set; } = string.Empty;

    public long FileSizeBytes { get; private set; }

    public string UploadedBy { get; private set; } = string.Empty;

    public DocumentStatus Status { get; private set; }

    public DateTime UploadedAtUtc { get; private set; }

    public DateTime? ProcessedAtUtc { get; private set; }

    public string? FailureReason { get; private set; }

    public void MarkAsProcessing()
    {
        Status = DocumentStatus.Processing;
        FailureReason = null;
    }

    public void MarkAsIndexed()
    {
        Status = DocumentStatus.Indexed;
        ProcessedAtUtc = DateTime.UtcNow;
        FailureReason = null;
    }

    public void MarkAsFailed(string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
        {
            throw new ArgumentException(
                "Failure reason is required.",
                nameof(reason));
        }

        Status = DocumentStatus.Failed;
        FailureReason = reason.Trim();
        ProcessedAtUtc = DateTime.UtcNow;
    }
}