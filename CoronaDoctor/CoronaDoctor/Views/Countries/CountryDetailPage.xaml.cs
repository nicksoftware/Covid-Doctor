using CoronaDoctor.Models.CoronaData;
using CoronaDoctor.ViewModels.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoronaDoctor.Views.Countries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryDetailPage : ContentPage
    {
        private CountryDetailViewModel context;
        

        public CountryDetailPage()
        {
            InitializeComponent();
        }

        public CountryDetailPage( CountryData data)
        {
            InitializeComponent();
            context = new CountryDetailViewModel(data);
            
            BindingContext = context;

            

            

        }

        private void backButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}