using System;

namespace Narvan.Domains.Commons
{
    public static class Generator
    {

        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}