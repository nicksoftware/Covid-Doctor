using CoronaDoctor.Models.SafetyTips;
using CoronaDoctor.ViewModels.SafetyTips;
using CoronaDoctor.Views.SafetyTipsDetailPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoronaDoctor.Views.SafetyTips.SafetyTipsList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SafetyTipsListPage : ContentPage
    {
        private SafetyTipsViewModel context;
        public SafetyTipsListPage()
        {
            InitializeComponent();
            context = new SafetyTipsViewModel();
            BindingContext = context;
        }

        private void safetyTipsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as SafetyTip;

            Navigation.PushAsync(new SafetyTipsDetailPage.SafetyTipsDetailPage(item));
        }

        private void safetyTipsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            safetyTipsList.SelectedItem = null;
        }

        private async void backButton_Clicked(object sender, EventArgs e)
        {
           await Navigation.PopAsync();
        }
    }
}