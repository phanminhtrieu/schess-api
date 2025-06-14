using SCHESS.CrossCuttingConcerns.Entity;

namespace SCHESS.Infrastructure.Provider.AzureBlob.Models
{
    public class BlobStorage : ValueObject
    {
        public string OriginalFileName { get; private set; }
        public string TimeStamp { get; private set; }
        public string ContainerSuffix { get; private set; }

        public BlobStorage(string timeStamp, string originalFileName, string containerSuffix)
        {
            OriginalFileName = originalFileName;
            TimeStamp = timeStamp;
            ContainerSuffix = containerSuffix;
        }

        public string GetFileName()
        {
            return $"{TimeStamp}-{OriginalFileName}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return OriginalFileName.ToLower();
            yield return TimeStamp.ToLower();
        }
    }
}
