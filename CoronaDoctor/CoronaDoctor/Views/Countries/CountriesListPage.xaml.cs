using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using CoronaDoctor.Services.CoronaService;
using CoronaDoctor.ViewModels.Countries;
using CoronaDoctor.Models.CoronaData;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace CoronaDoctor.Views.Countries
{
    /// <summary>
    /// Page to display the Contacts list.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountriesListPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountriesListPage" /> class.
        /// </summary>
        /// 
        private CountriesListViewModel context;
    
        public CountriesListPage()
        {
            InitializeComponent();
      

           context = new CountriesListViewModel();

            BindingContext = context;
        }

        /// <summary>
        /// Invoked when view size is changed.
        /// </summary>
        /// <param name="width">The Width</param>
        /// <param name="height">The Height</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > height)
            {
                if (Search.IsVisible)
                {
                    Search.WidthRequest = width;
                }
            }
        }

        /// <summary>
        /// Invoked when search button is clicked.
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">Event Args</param>
        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            this.Search.IsVisible = true;
            this.CountriesTitle.IsVisible = false;

            if (this.CountriesTitleView != null)
            {
                double opacity;

                // Animating Width of the search box, from 0 to full width when it added to the view.
                var expandAnimation = new Animation(
                    property =>
                    {
                        Search.WidthRequest = property;
                        opacity = property / CountriesTitleView.Width;
                        Search.Opacity = opacity;
                    }, 0, CountriesTitleView.Width, Easing.Linear);
                expandAnimation.Commit(Search, "Expand", 16, 250, Easing.Linear);
            }

            SearchEntry.Focus();
        }

        /// <summary>
        /// Invoked when back to title button is clicked.
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">Event Args</param>
        private void BackToTitle_Clicked(object sender, EventArgs e)
        {
            this.SearchButton.IsVisible = true;
          
            if (this.CountriesTitleView != null)
            {
                double opacity;

                // Animating Width of the search box, from full width to 0 before it removed from view.
                var shrinkAnimation = new Animation(property =>
                {
                    Search.WidthRequest = property;
                    opacity = property / CountriesTitleView.Width;
                    Search.Opacity = opacity;
                },
                CountriesTitleView.Width, 0, Easing.Linear);
                shrinkAnimation.Commit(Search, "Shrink", 16, 250, Easing.Linear, (p, q) => this.SearchBoxAnimationCompleted());
            }

            SearchEntry.Text = string.Empty;
        }

        /// <summary>
        /// Invokes when search box Animation completed.
        /// </summary>
        private void SearchBoxAnimationCompleted()
        {
            this.Search.IsVisible = false;
            this.CountriesTitle.IsVisible = true;
        }

        private async Task LoadData()
        {
          shimmer.IsActive = await context.GetDataAsync();
  
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

           await LoadData();
            CountryList.ItemsSource = context.CountriesList;

        }

        private void CountryList_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var item = e.ItemData as CountryData;

            Navigation.PushAsync(new CountryDetailPage(item));
        }

        private async void CountryList_Loaded(object sender, Syncfusion.ListView.XForms.ListViewLoadedEventArgs e)
        {
            await LoadData();
            CountryList.IsBusy = false;

        }

        private async void backButton_Clicked(object sender, EventArgs e)
        {
          await  Navigation.PopAsync();
        }

        private   void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = e.NewTextValue;
        

            if (string.IsNullOrWhiteSpace(searchText))
            {
                CountryList.ItemsSource = context.CountriesList;
            }
            else
            {
                searchText = searchText.ToLower();
                CountryList.ItemsSource = context.CountriesList.Where(c => c.Country.ToLower().Contains(searchText));
            }
           

        }
    }
}