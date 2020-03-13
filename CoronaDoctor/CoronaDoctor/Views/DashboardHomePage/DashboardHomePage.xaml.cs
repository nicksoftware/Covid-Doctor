using CoronaDoctor.Data;
using CoronaDoctor.Models.CoronaData;
using CoronaDoctor.Models.DashboardHomePage;
using CoronaDoctor.Services.CoronaService;
using CoronaDoctor.ViewModels.DashboardHomePage;
using CoronaDoctor.Views.AboutUs;
using CoronaDoctor.Views.Countries;
using CoronaDoctor.Views.SafetyTips.SafetyTipsList;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CoronaDoctor.Views.DashboardHomePage
{
    /// <summary>
    /// Page to show the health care details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardHomePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardHomePage" /> class.
        /// </summary>
        public static Xamarin.Essentials.NetworkAccess NetworkAccess { get; }


        private DashboardViewModel context;
        public DashboardHomePage()
        {
            InitializeComponent();
            context = new DashboardViewModel();

            BindingContext = context;
  
        }


        /*!- Bottom Navigation items -*/
        private void navigationList_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var item = e.ItemData as NavigationItem;

            if (item.Category.Contains("Self Diagnosis"))
            {
                Navigation.PushAsync(new DiagnosisPage());
            }
            else if (item.Category.Contains("Countries")) 
            {
             Navigation.PushAsync(new CountriesListPage());

            }else if (item.Category.Contains("About"))
            {
                Navigation.PushAsync(new AboutUsSimplePage());

            }else if(item.Category.Contains("How to Stay Safe"))
            {
                Navigation.PushAsync(new SafetyTipsListPage());
            }
                
        }
           

        //CoonectivityEventMonitor 
        private async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var currentNetworkState = Connectivity.NetworkAccess;
 
            switch (currentNetworkState)
            {
                case NetworkAccess.None:
                    {
                        await DisplayAlert("Failed to connect", "Switch on your mobile data or Connect to a wifi to recieve updates", "Ok");
                        break;
                    }
                case NetworkAccess.Local:
                    {
                        await DisplayAlert("Failed to connect", "Local connection detected", "Ok");
                        break;
                    }
                case NetworkAccess.Unknown:
                    {
                        await DisplayAlert("Failed to connect", "Unknown connection detected", "Ok");
                        break;
                    }

                case NetworkAccess.Internet:
                {
                        var result = await context.GetStatesData();
                        if (result != null)
                        {
                            
                            menuList.ItemsSource = result;
                            shimmer.IsActive = context.IsContentLoading;


                        }
                        break;
                }
                default:
                    {
                        await DisplayAlert("Error", "Unknown error failed to retrieve data", "Ok");
                        break;
                    }
            }
        }
        protected async  override  void OnAppearing()
        {

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            var currentNetworkState = Connectivity.NetworkAccess;

            switch (currentNetworkState)
            {
                case NetworkAccess.None:
                    {
                      await  DisplayAlert("Failed to connect","Switch on your mobile data of Connect to a wifi to recieve updates","Ok");
                        break;
                    }
                case NetworkAccess.Local:
                    {
                        await DisplayAlert("Failed to connect", "Local connection detected", "Ok");
                        break;
                    }
                case NetworkAccess.Unknown:
                    {
                        await DisplayAlert("Failed to connect", "Unknown connection detected", "Ok");
                        break;
                    }
                default:
                    {
                        var result = await context.GetStatesData();
                        if (result != null)
                        {
                        
                            menuList.ItemsSource = result;
                            shimmer.IsActive = context.IsContentLoading;

                        }
                        break;
                    }
            }
            base.OnAppearing();
        
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }

        private async void shareButton_Clicked(object sender, System.EventArgs e)
        {

            var share = new ShareTextRequest();
            share.Title = AppInfo.Name;
            share.Subject = "Please checkout this App";
            share.Uri =  Constants.AppUrl;
            share.Text = "Hey, are you also stressing about the nCovid outbreak and don't know how to protect yourself and your family ? No worries The Covid Doctor " +
                " just the application you need.The application will help advice  and keep you up to date with the latest" +
                " nCovid cases and will also offer safety tips to help protect you and your family from the terrifying nCovid Virus.";
    
          await  Share.RequestAsync(share);
        }
    }
}
