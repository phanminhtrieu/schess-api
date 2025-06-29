namespace SCHESS.CrossCuttingConcerns.Dtos
{
    public class ApiResult<T>
    {
        public bool IsSucceeded { get; set; }

        public string? Message { get; set; }

        public T? ResultObj { get; set; }
    }
}
