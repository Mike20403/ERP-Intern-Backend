namespace Api.Hubs
{
    public static class HubExtensions
    {
        public static string ToProjectGroup(this Guid @this) => $"projects:{@this}";
    }
}
