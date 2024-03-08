namespace AdminStarterKit.Api.Contracts
{
    public class CommonApiResponse<T>
    {
        public static CommonApiResponse<T> Success(T data, string message = "") => new()
        {
            Succeeded = true,
            Message = message,
            Data = data
        };

        public static CommonApiResponse<T> Failed(string message) => new()
        {
            Succeeded = false,
            Message = message
        };

        public bool Succeeded { get; protected set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
