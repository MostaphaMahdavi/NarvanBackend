using System;
using System.Security.Claims;

namespace Narvan.WebApi.Utilities.Extentions.Identities
{
    public static class IdentityExtention
    {

        public static long GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var result = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
                var res002 = claimsPrincipal.FindFirstValue("nameidentifier");

                return Convert.ToInt64(result.Value);
            }

            return default(long);
        }

    }
}