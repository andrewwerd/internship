using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Extensions
{
    public static class GuidExtensions
    {
        public static string NewShortGuid(this Guid guid)
        {
            return Convert.ToBase64String(guid.ToByteArray());
        }
    }
}
