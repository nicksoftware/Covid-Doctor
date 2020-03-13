using CoronaDoctor.Services;
using System;
using Xamarin.Essentials;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CoronaDoctor.Views.AboutUs
{
    /// <summary>
    /// About us simple page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutUsSimplePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CoronaDoctor.Views.AboutUs.AboutUsSimplePage"/> class.
        /// </summary>
        public AboutUsSimplePage()
        {
            InitializeComponent();
        }

        private async void btnGetToKnowMe_Clicked(object sender, System.EventArgs e)
        {
            var browser = new BrowserApi();
            var url = new Uri(App.MyWebSiteURL);
           await browser.OpenBrowser(url);

            
        }

        private void backButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void shareButton_Clicked(object sender, EventArgs e)
        {
            var share = new ShareTextRequest();
            share.Title = AppInfo.Name;
            share.Subject = "Please checkout this App";
            share.Uri = "https://play.google.com/store/apps/" + AppInfo.PackageName;
            share.Text = "Hey, are you also stressing about the nCovid outbreak and don't know that to do ? No worries The Covid Doctor " +
                " just the application you need.The application will help advice  and keep you up to date with the latest" +
                " nCovid cases and will also offer safety tips.";

            await Share.RequestAsync(share);
        }
    }
}