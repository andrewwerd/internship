namespace WebApi.Infrastructure.Extensions
{
    public static class GuidExtensions
    {
        public static string NewShortGuid(this Guid guid)
        {
            return Convert.ToBase64String(guid.ToByteArray());
        }
    }
}
