using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
