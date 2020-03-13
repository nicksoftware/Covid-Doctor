using CoronaDoctor.Data;
using CoronaDoctor.Models.CoronaData;
using CoronaDoctor.Services.CoronaService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CoronaDoctor.ViewModels.Countries
{

    [Preserve(AllMembers = true)]
    [DataContract]
    class CountriesListViewModel :BaseViewModel
    {
        #region Fields
        private CoronaService coronaService;
        private Command<object> itemTappedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="CountriesListViewModel"/> class.
        /// </summary>
        public CountriesListViewModel()
        {
            coronaService = new CoronaService();
            CountriesList = new ObservableCollection<CountryData>();
            IsContentLoading = true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        /// 
        public bool IsContentLoading { get; set; }
        public Command<object> ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command<object>(this.NavigateToNextPage));
            }
        }

    
        /// <summary>
        /// Gets or sets a collction of value to be displayed in contacts list page.
        /// </summary>
        [DataMember(Name = "CountriesPageList")]
        public ObservableCollection<CountryData> CountriesList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the contacts list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            var item = selectedItem as CountryData;
            
            // Do something
        }

        public async Task<bool> GetDataAsync()
        {
          var content = await coronaService.GetCoronaDataAsync(Constants.CORONA_AFFECTED_COUNTRIES_ENDPOINT);

            if(content != null)
            {
                CountriesList =  content ;
               return   false;

            }
            else
            {
               return true;
            }
        }

        #endregion
    }

}

