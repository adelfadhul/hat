using MauiApp = Microsoft.Maui.Controls.Application;

namespace Hat.Helpers
{
    public static class AlertHelper
    {
        public static void ShowAlert(string title, string message, string cancelButtonText,FlowDirection flowDirection)
        {
            MauiApp.Current.MainPage.DisplayAlert(title, message, cancelButtonText,flowDirection);
        }
    }
}
