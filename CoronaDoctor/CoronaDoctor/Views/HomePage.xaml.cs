using CoronaDoctor.Models;
using CoronaDoctor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoronaDoctor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }

        private void NavigationList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            NavigationList.SelectedItem = null;
        }

        private async void NavigationList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelected = e.Item as NavigationItem;
            if (itemSelected.Title.Contains("Diagnosis"))
            {
                await Navigation.PushAsync(new DiagnosisPage());
            }
            else if (itemSelected.Title.Contains("Learn About Corona"))
            {
               // await Navigation.PushAsync(new CoronaInformationPage());
            }

        }
    }
}