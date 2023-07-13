namespace WebApi.CustomExceptionMiddleware
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
