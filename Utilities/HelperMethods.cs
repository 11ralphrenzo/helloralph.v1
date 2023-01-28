using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;

namespace helloralph.Utilities
{
    public static class HelperMethods
    {
        // Connectivity
        public static bool HasConnection()
        {
            return Connectivity.Current.NetworkAccess != NetworkAccess.None;
        }

        // Alerts
        public async static void DisplayAlert(string title, string message, string button)
        {
            await Shell.Current.DisplayAlert(title, message, button);
        }

        public static void Toast(string message, bool isShort = true)
        {
            CommunityToolkit.Maui.Alerts.Toast.Make("", isShort ? ToastDuration.Short : ToastDuration.Long);
        }

        // Inputs

        public async static Task<string> ActionSheet(string title, string cancelButton, string destruction, string[] buttons)
        {
            return await Shell.Current.DisplayActionSheet(title, cancelButton, destruction, buttons);
        }

        
    }
}
