using CoronaDoctor.Data;
using CoronaDoctor.Models.SafetyTips;
using CoronaDoctor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CoronaDoctor.Views.SafetyTipsDetailPage
{
    /// <summary>
    /// Article parallax header page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SafetyTipsDetailPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SafetyTipsDetailPage"/> class.
        /// </summary>
        public SafetyTipsDetailPage()
        {
            InitializeComponent();
        }

        public SafetyTipsDetailPage(SafetyTip safetyTip)
        {

            InitializeComponent();

            BindingContext = safetyTip;
        }

        private async void backButton_Clicked(object sender, EventArgs e)
        {
          await  Navigation.PopAsync();
        }

        private async void shareButton_Clicked(object sender, EventArgs e)
        {

            var share = new ShareTextRequest();
            share.Title = AppInfo.Name;
            share.Subject = "Please checkout this App";
            share.Uri = Constants.AppUrl;
            share.Text = "Hey, are you also stressing about the nCovid outbreak and don't know that to do ? No worries The Covid Doctor " +
                " just the application you need.The application will help advice  and keep you up to date with the latest" +
                " nCovid cases and will also offer safety tips.";

            await Share.RequestAsync(share);

        }
    }
}