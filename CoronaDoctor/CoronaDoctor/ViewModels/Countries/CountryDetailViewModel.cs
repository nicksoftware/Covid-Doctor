using CoronaDoctor.Models.CoronaData;
using CoronaDoctor.Models.DashboardHomePage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CoronaDoctor.ViewModels.Countries
{

    class CountryDetailViewModel
    {
        public string Country { get; set; }
        public int Cases { get; set; }
        public int Recovered { get; set; }
        public int Deaths { get; set; }
        public int Critical { get; set; }
        public  int TodayCases { get; set; }
        public int TodayDeaths { get; set; }

        public ObservableCollection<NavigationItem> CardItems { get; set; }
        public CountryDetailViewModel(CountryData data)
        {
            Country = data.Country;
            Cases = data.Cases;
            Recovered = data.Recovered;
            Deaths = data.Deaths;
            Critical = data.Critical;
            TodayCases = data.TodayCases;
            TodayDeaths = data.TodayDeaths;

            CardItems = CreateCards();
            
        }



        public ObservableCollection<NavigationItem> CreateCards()
        {
            return new ObservableCollection<NavigationItem>()
                    {
                        new NavigationItem()
                        {
                            Category = "CASES",
                            CategoryValue = Cases.ToString(),
                   
                            BackgroundGradientStart = "#f59083",
                            BackgroundGradientEnd = "#fae188",
                        },
                        new NavigationItem()
                        {
                            Category = "DEATHS",
                            CategoryValue = Deaths.ToString(),
                     
                            BackgroundGradientStart = "#ff7272",
                            BackgroundGradientEnd = "#f650c5"
                        },
                        new NavigationItem()
                        {
                            Category = "RECOVERED",
                            CategoryValue =  Recovered.ToString(),
                      
                            BackgroundGradientStart = "#5e7cea",
                            BackgroundGradientEnd = "#1dcce3"
                        },
                        new NavigationItem()
                        {
                            Category = "CRITICAL",
                            CategoryValue = Critical.ToString(),
                            BackgroundGradientStart = "#255ea6",
                            BackgroundGradientEnd = "#b350d1"
                        },
                        new NavigationItem()
                        {
                            Category = "TODAY CRITICAL",
                            CategoryValue = Critical.ToString(),
                          BackgroundGradientStart = "#ff7422",
                            BackgroundGradientEnd = "#eb7a34"
                        },
                        new NavigationItem()
                        {
                            Category = "TODAY DEATHS",
                            CategoryValue = Critical.ToString(),
                            BackgroundGradientStart = "#eb3434",
                            BackgroundGradientEnd = "#eb3462"
                        }
                    };
        }
    }
}

