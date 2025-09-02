using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            if (claimsPrincipal == null || string.IsNullOrWhiteSpace(claimType))
                return new List<string>();

            return claimsPrincipal.FindAll(claimType)
                                  .Select(x => x.Value)
                                  .ToList();
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role) ?? new List<string>();
        }
    }
}
