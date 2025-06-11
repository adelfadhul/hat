namespace Hat.Domain.Helpers
{
    public static class EnumHelper
    {
        public static TEnum ParseOrDefault<TEnum>(string value, TEnum defaultValue) where TEnum : struct, Enum
        {
            return Enum.TryParse<TEnum>(value, true, out var result) ? result : defaultValue;
        }
    }
}
