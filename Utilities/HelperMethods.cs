using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloralph.Utilities
{
    public static class HelperMethods
    {
        public static bool HasConnection()
        {
            return Connectivity.Current.NetworkAccess != NetworkAccess.None;
        }

        public static void DisplayAlert(string title, string message, string button)
        {
            Application.Current.MainPage.DisplayAlert(title, message, button);
        }

        public async static Task<string> ActionSheet(string title, string cancelButton, string destruction, string[] buttons)
        {
            return await Application.Current.MainPage.DisplayActionSheet(title, cancelButton, destruction, buttons);
        }
    }
}
