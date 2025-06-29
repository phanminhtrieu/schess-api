namespace SCHESS.CrossCuttingConcerns.Entity
{
    public class IBlob
    {
        public Guid Id { get; set; }

        public Stream? FileStream { get; set; }

        public string? ExtensionWithDot { get; set; }

        public string? AttachmentUrl { get; set; }
    }
}
