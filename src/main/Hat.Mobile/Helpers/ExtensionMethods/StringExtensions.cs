using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.Helpers.ExtensionMethods
{
    internal static class StringExtensions
    {
        public static Color ToColorFromResourceKey(this string resourceKey)
        {
            return MauiApp.Current.Resources
                .MergedDictionaries.First()[resourceKey] as Color;
        }
    }

}
