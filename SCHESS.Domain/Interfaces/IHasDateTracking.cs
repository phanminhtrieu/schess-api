namespace SCHESS.Domain.Interfaces
{
    public interface IHasDateTracking
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
