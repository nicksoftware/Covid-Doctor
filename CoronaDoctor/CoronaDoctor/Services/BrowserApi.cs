using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CoronaDoctor.Services
{
 class BrowserApi
    {
       public async Task<bool> OpenBrowser(Uri uri)
        {
            return await Browser.OpenAsync(uri, new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Hide,
                PreferredControlColor = ColorConverters.FromHex("#ff7272"),
                PreferredToolbarColor = ColorConverters.FromHex("#f650c5")
            });
        }
    }
}
