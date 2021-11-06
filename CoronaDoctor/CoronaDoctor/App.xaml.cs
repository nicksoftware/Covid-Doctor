using CoronaDoctor.Data;
using CoronaDoctor.Services.CoronaService;
using CoronaDoctor.Views;
using CoronaDoctor.Views.DashboardHomePage;

using Plugin.LocalNotifications;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoronaDoctor
{
    public partial class App : Application
    {
        public static string MyWebSiteURL { get; } = "https://hnicolus.github.io/My-Portfolio";
        public static string BaseImageUrl { get; } = "https://hnicolus.github.io/My-Portfolio/assets/images/img-20191106-120902-2000x1483.jpg";
        private CoronaService coronaService;
        private Random random;
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("");
            InitializeComponent();
            random = new Random();
            coronaService = new CoronaService();
            MainPage = new NavigationPage(new DashboardHomePage());
        }

        protected async override void OnStart()
        {
            var choice = random.Next(1, 5);

            var content = await coronaService.GetCoronaDataAsync(Constants.CORONA_AFFECTED_COUNTRIES_ENDPOINT);
            if (content != null)
            {
                if (DateTime.Now.Hour < 10)
                {
                    CrossLocalNotifications.Current.Show($"nCovid Updates", $"This morning {content.Sum(b => b.TodayCases)} number people have tested positive for nCovid-19 globally and now the total number of reported cases has increased to {content.Sum(tc => tc.Cases)}", 101, DateTime.Now.AddMinutes(5));

                }
                else if (DateTime.Now.Hour > 12 && DateTime.Now.Hour < 15)
                {
                    CrossLocalNotifications.Current.Show("nCovid Updates", $"The total number the global epidemic nCovid-19 virus cases is currently at" +
                    $"{content.Sum(c => c.Cases)} and {content.Sum(c => c.TodayCases)} " +
                    $"of which are were newly reported today. The number of fatal cases today is {content.Sum(c => c.TodayDeaths)}.Please remember to follow the safety tips provided to stay safe and avoid over crowded areas", 102, DateTime.Now.AddMinutes(5));
                }
                else if (DateTime.Now.Hour > 20)
                {
                    CrossLocalNotifications.Current.Show("nCovid-19 Updates", $"Today the was  atleast {content.Sum(b => b.TodayDeaths)} fatal cases all over the world.");
                }
            }


        }

        protected override void OnSleep()
        {
            var choice = random.Next(1, 6);

            switch (choice)
            {
                case 1:
                    {
                        CrossLocalNotifications.Current.Show("Remember", "Don't forget to wash your hands", 101, DateTime.Now.AddMinutes(5));
                        break;
                    }
                case 2:
                    {

                        CrossLocalNotifications.Current.Show("Remember", "If you not feeling well please stay at home and wear a mask to protect your friends and loved ones loved", 102, DateTime.Now.AddMinutes(4));
                        break;
                    }
                case 3:
                    {
                        CrossLocalNotifications.Current.Show("Remember", "Use a disposable tissue to handle public Door knobs.", 102, DateTime.Now.AddSeconds(5));

                        break;
                    }
                case 4:
                    {
                        CrossLocalNotifications.Current.Show("Remember", "Please try your best to avoid handshakes.", 102, DateTime.Now.AddMinutes(14));
                        break;

                    }
                case 5:
                    {
                        CrossLocalNotifications.Current.Show("Remember", "Please try your best to avoid touching public surfaces.", 102, DateTime.Now.AddSeconds(5));
                        break;

                    }
                case 6:
                    {
                        CrossLocalNotifications.Current.Show("Remember", "The Covid Doctor is always here for you.", 102, DateTime.Now.AddMinutes(5));
                        break;
                    }
            }
        }

        protected override void OnResume()
        {
            var choice = random.Next(1, 3);

            switch (choice)
            {
                case 1:
                    {
                        CrossLocalNotifications.Current.Show("Reminder", "Did you wash your hands?", 101, DateTime.Now.AddMinutes(5));
                        break;
                    }
                case 2:
                    {

                        CrossLocalNotifications.Current.Show("Reminder", "Did you clean your  gadgets ", 102, DateTime.Now.AddMinutes(10));
                        break;
                    }
                case 3:
                    {
                        CrossLocalNotifications.Current.Show("Please", "Share the application with your  friends and families", 102, DateTime.Now.AddSeconds(5));

                        break;
                    }
  
            }
        }
    }
}
