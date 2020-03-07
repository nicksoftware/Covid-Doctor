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
    public partial class DiagnosisPage : ContentPage
    {
        private int numberOfCheckedItems;
        private DiagnosisViewModel viewModel;

        public DiagnosisPage()
        {
            InitializeComponent();
            viewModel = new DiagnosisViewModel();
            BindingContext = viewModel;
            numberOfCheckedItems = 0;
        
        }

        private void checkList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            checkList.SelectedItem = null;
        }

        private void checkList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as CheckItem;
            DisplayAlert("Tapped", $"{item.Detail} - isChecked status :{item.IsChecked}", "Ok");
        }



        private void checkbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var status = e.Value;

            if (status)
            {
                numberOfCheckedItems++;
            }
            else
            {
                numberOfCheckedItems--;
            }
            
        }

        private async void btnGetDiagnosis_Clicked(object sender, EventArgs e)
        {


            var results = viewModel.GetDiagnosis(numberOfCheckedItems);

            await DisplayAlert("Results", String.Format("The Diagnosis Report Feedbacks states - {0}", results), "Ok");

        }
    }
}