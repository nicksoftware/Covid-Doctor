using Syncfusion.SfRating.XForms.iOS;
using Syncfusion.XForms.iOS.ProgressBar;
using Syncfusion.XForms.iOS.Cards;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.XForms.iOS.Graphics;
using Syncfusion.XForms.iOS.Buttons;
using Syncfusion.XForms.iOS.Border;
using Syncfusion.SfChart.XForms.iOS.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using UserNotifications;
using Syncfusion.XForms.iOS.Core;

namespace CoronaDoctor.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //Google.MobileAds.MobileAds.Configure("ca-app-pub-1234567891234567~1234567890");
            global::Xamarin.Forms.Forms.Init();
            SfRatingRenderer.Init();
            SfAvatarViewRenderer.Init();
            SfLinearProgressBarRenderer.Init();
            SfCardViewRenderer.Init();
            SfListViewRenderer.Init();
            SfGradientViewRenderer.Init();
            SfChartRenderer.Init();
            SfButtonRenderer.Init();
            SfBorderRenderer.Init();
            LoadApplication(new App());

            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                // Ask the user for permission to get notifications on iOS 10.0+
                UNUserNotificationCenter.Current.RequestAuthorization(
                        UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound,
                        (approved, error) => { });
            }
            else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                // Ask the user for permission to get notifications on iOS 8.0+
                var settings = UIUserNotificationSettings.GetSettingsForTypes(
                        UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                        new NSSet());

                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }

            return base.FinishedLaunching(app, options);
        }
    }
}
