namespace WebApi.RequestError
{
    public class ApiRequestError : Exception
    {
        public int StatusCode { get; set; }

        public ApiRequestError(int statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
