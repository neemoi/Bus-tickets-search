using Microsoft.AspNetCore.Identity;

namespace Application.Services.Helper
{
    public static class ErrorString
    {
        public static string GetErrorString(this IdentityResult result)
        {
            return string.Join("; ", result.Errors.Select(x => x.Description));
        }
    }
}
