using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CoronaDoctor.Data;
using CoronaDoctor.Models.CoronaData;
using CoronaDoctor.Models.DashboardHomePage;
using CoronaDoctor.Services.CoronaService;
using CoronaDoctor.ViewModels.SafetyTips;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CoronaDoctor.ViewModels.DashboardHomePage
{
    /// <summary>
    /// ViewModel for stock overview page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class DashboardViewModel : BaseViewModel
    {
        CoronaService coronaService;

        private int? numCountriesAffected = 0 ;
        public CoronaStatesData StatesDataContext { get; set; }
    
        public bool IsContentLoading { get; set; }

        #region Field

        /// <summary>
        /// To store the health care data collection.
        /// </summary>
        private ObservableCollection<NavigationItem> cardItems;

        /// <summary>
        /// To store the health care data collection.
        /// </summary>
        private ObservableCollection<NavigationItem> listItems;

        /// <summary>
        /// To store the heart rate data collection.
        /// </summary>
        private ObservableCollection<ChartDataPoint> CasesData;

        /// <summary>
        /// To store the calories burned data collection.
        /// </summary>
        private ObservableCollection<ChartDataPoint> DeathsData;

        /// <summary>
        /// To store the sleep time data collection.
        /// </summary>
        private ObservableCollection<ChartDataPoint> RecoveredData;

        /// <summary>
        /// To store the water consumed data collection.
        /// </summary>
        private ObservableCollection<ChartDataPoint> CriticalData;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="DashboardViewModel" /> class.
        /// </summary>
        public DashboardViewModel()
        {
            coronaService = new CoronaService();

            CasesData = new ObservableCollection<ChartDataPoint>();
            DeathsData = new ObservableCollection<ChartDataPoint>();
            CriticalData = new ObservableCollection<ChartDataPoint>();
            RecoveredData = new ObservableCollection<ChartDataPoint>();

            IsContentLoading = true;
            cardItems =CreateCards();

            numCountriesAffected = null;

            listItems = CreateListItems();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the profile image path.
        /// </summary>
        public string ProfileImage { get; set; }

        /// <summary>
        /// Gets or sets the health care items collection.
        /// </summary>
        public ObservableCollection<NavigationItem> CardItems
        {
            get
            {
                return this.cardItems;
            }

            set
            {
                this.cardItems = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the health care items collection.
        /// </summary>
        public ObservableCollection<NavigationItem> ListItems
        {
            get
            {
                return this.listItems;
            }

            set
            {
                this.listItems = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion


        #region Methods

        /// <summary>
        /// Chart Data Collection
        /// </summary>
        /// 
        public async Task<ObservableCollection<NavigationItem>> GetStatesData()
        {
            var countries = await coronaService.GetCoronaDataAsync(Constants.CORONA_AFFECTED_COUNTRIES_ENDPOINT);
            var numberOfCriticalPeople = 0;
            
            if (countries != null)
            {
                numCountriesAffected = countries.Count;

                cardItems = CreateCards(
                    cases: countries.Sum(c => c.Cases),
                    deaths: countries.Sum(c => c.Deaths),
                    recovered: countries.Sum(c => c.Recovered),
                    critical: countries.Sum(c => c.Critical),
                    todayCases: countries.Sum(c => c.TodayCases),
                    todayDeaths: countries.Sum(c => c.TodayDeaths));
                IsContentLoading = false;
                ListItems = CreateListItems(Convert.ToInt32(numCountriesAffected));
                var time = DateTime.Now.Second;
                foreach (var c in countries)
                {
                    numberOfCriticalPeople += c.Critical;

                    CasesData.Add(new ChartDataPoint(time, c.Cases));

                    DeathsData.Add(new ChartDataPoint(time, c.Deaths));

                    RecoveredData.Add(new ChartDataPoint(time, c.Recovered));

                    CriticalData.Add(new ChartDataPoint(time, c.Critical));

                }
            }
            else
            {
                cardItems = CreateCards();
                IsContentLoading = true;
                ListItems = CreateListItems();
            }

            return CardItems;

        }

        public ObservableCollection<NavigationItem> CreateCards(int cases = 0 , int deaths = 0,
            int recovered = 0 , int critical =  0,int todayCases = 0 ,int todayDeaths = 0 )
        {
              return new ObservableCollection<NavigationItem>()
                    {
                        new NavigationItem()
                        {
                            Category = "CASES",
                            CategoryValue = cases == 0 ? "" :  cases.ToString(),
                            
                            BackgroundGradientStart = "#f59083",
                            BackgroundGradientEnd = "#fae188",
                        },
                        new NavigationItem()
                        {
                            Category = "DEATHS",
                            CategoryValue = deaths == 0 ? "" :  deaths.ToString(),
                           
                            BackgroundGradientStart = "#ff7272",
                            BackgroundGradientEnd = "#f650c5"
                        },
                        new NavigationItem()
                        {
                            Category = "RECOVERED",
                            CategoryValue =  recovered == 0 ? "" :  recovered.ToString(),
                           
                            BackgroundGradientStart = "#5e7cea",
                            BackgroundGradientEnd = "#1dcce3"
                        },
                        new NavigationItem()
                        {
                            Category = "CRITICAL",
                            CategoryValue =  critical == 0 ? "" :  critical.ToString(),
                            ChartData = CriticalData,
                            BackgroundGradientStart = "#255ea6",
                            BackgroundGradientEnd = "#b350d1"
                        },
                        new NavigationItem()
                        {
                            Category = "CASES TODAY",
                            CategoryValue =  todayCases == 0 ? "" :  todayCases.ToString(),
                            ChartData = CriticalData,
                            BackgroundGradientStart = "#ff7422",
                            BackgroundGradientEnd = "#eb7a34"
                        },
                         new NavigationItem()
                        {
                            Category = "DEATHS TODAY",
                            CategoryValue =  todayDeaths == 0 ? "" :  todayDeaths.ToString(),
                            ChartData = CriticalData,
                            BackgroundGradientStart = "#eb3434",
                            BackgroundGradientEnd = "#eb3462"
                        }
                    };
        }



        public ObservableCollection<NavigationItem> CreateListItems(int AffectedCountries = 0)
        {
            var safetyTips = new SafetyTipsViewModel();
            var numOfSafetyTips = safetyTips.safetyTips.Count();


            var countriesAffectedPercentage =Math.Round(((double) AffectedCountries / 195 )* 100,0);
            var items =  new ObservableCollection<NavigationItem>()
            {
                new NavigationItem()
                {
                    Category = "Affected Countries",
                    CategoryValue =  AffectedCountries != 0 ? AffectedCountries.ToString() : "",
                    CategoryPercentage = AffectedCountries != 0 ? countriesAffectedPercentage.ToString()+"%" : "",
                    BackgroundGradientStart = "#ff9686"
                },

                new NavigationItem()
                {
                    Category = "How to Stay Safe",
                    CategoryValue =numOfSafetyTips.ToString(),
                    CategoryPercentage = "Get tips",
                    BackgroundGradientStart = "#8691ff"
                },

                new NavigationItem()
                {
                    Category = "Do Self Diagnosis",
                    CategoryValue = "",
                    CategoryPercentage = "Not feeling well?",
                    BackgroundGradientStart = "#cf86ff"
                },

                new NavigationItem()
                {
                    Category = "About App",
                    CategoryValue = "",
                    CategoryPercentage = "",
                    BackgroundGradientStart = "#8656ff"
                },
            };

            return items;
        }
        #endregion
    }
}
