namespace WebApi.RequestError
{
    public class ApiRequestErrorException : Exception
    {
        public int StatusCode { get; set; }

        public ApiRequestErrorException(int statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}