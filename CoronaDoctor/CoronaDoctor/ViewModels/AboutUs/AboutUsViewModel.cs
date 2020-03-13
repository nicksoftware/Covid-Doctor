using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CoronaDoctor.Models.AboutUs;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CoronaDoctor.ViewModels.AboutUs
{
    /// <summary>
    /// ViewModel of AboutUs templates.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AboutUsViewModel : BaseViewModel
    {
        #region Fields

        private string productDescription;
        public string AboutDeveloper { get; }
        public string SoftwareServices { get; }

        private string productVersion;
        public string AboutLogoDesigner { get; set; }

        private string productIcon;

        private string cardsTopImage;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="T:CoronaDoctor.ViewModels.AboutUs.AboutUsViewModel"/> class.
        /// </summary>
        public AboutUsViewModel()
        {
            this.productDescription =
                "Corona Doctor is a self-sustained Application that has been designed and developed to investigate and provide users with Real Time updates of the  current  corona Virus " +
                "Epidemic Crisis.It has also been designed to help users stay safe by giving them daily tips to better protected themselve and also reminds  them to be constantly concious on the go." +
                "\n" ;
     
            this.productVersion = AppInfo.VersionString;
 
            SoftwareServices = "The Application gathers infomation " +
                "from many various sources thus the data gathered information may sometimes not be 100% accurate ," +
                "but our developers have programmed the application to make use of " +
                "Artificial Intelligent features to filter and increase the data's accurency to 94%. \n" +
                " \n \nWhy Our Application is not on play Store\n \n" +
                "The content of provided by the application may contain unfiltered , sensitive and to others disturbing  information about the current nCovid outbreak and since the program's " +
                " primary objective is to find , analyse, seperate filter and reveal  information .Some have pro-claimed the program as obscurent." +
                "\n \nWhy are we not monetizing with the product \n \n " +
                "Due to the contents sensitivity we find it wrong that making profit out such a crisis for self pro-claimed gain will be such an immoralistic act.\n\n\n" +
                " ";


            this.EmployeeDetails = new ObservableCollection<AboutUsModel>
            {
                new AboutUsModel
                {
                    EmployeeName = "Ikageng Thitane", HasWebSite= false,
                    Designation = "Data Analyst & Digital Marketer",
                    BackgroundHistory = "first year student studying applied mathematics and computer science and also a marketer"

                },
                new AboutUsModel
                {
                    EmployeeName = "Dzunisani  Percival  Maila",
                    Designation = "Data analyst",HasWebSite= false,
                    BackgroundHistory = "Computer Science and Informatics student at the University of Johannesburg and I love working with numbers.",
                },
                new AboutUsModel
                {
                    EmployeeName = "Sibusiso Matthews Mfana",HasWebSite= false,
                    Designation = "Researcher & Digital Marketer",
                    BackgroundHistory = "computer science student and digital Marketer.Interested in data Privacy and Cyber security as well as Software Architecture",
                },
                new AboutUsModel
                {
                    EmployeeName = "Tiyiselani Mabunda",HasWebSite= false,
                    BackgroundHistory = "I am a Computer Science Student, graphic designer and marketer.I am passionate about computer science in relation to Data science and marketing.",
                    Designation = "Digital Marketer &  Designer"
                },
                new AboutUsModel
                {
                    EmployeeName = "Nicolas Maluleke",
          
                    HasWebSite= true,

                    WebSiteUrl = App.MyWebSiteURL,

                    Image = App.BaseImageUrl,

                    BackgroundHistory =  "I am a freelancer full-stack developer and a student who loves Creating Softwares(including this one) that help" +
                                         " make the world a better and safe place." +
                                         "I am also a Computer Science student.",

                    Designation = "Software Developer"
                },

            };

            this.ItemSelectedCommand = new Command(this.ItemSelected);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the top image source of the About us with cards view.
        /// </summary>
        /// <value>Image source location.</value>
        public string CardsTopImage
        {
            get
            {
                return this.cardsTopImage;
            }

            set
            {
                this.cardsTopImage = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the description of a product or a company.
        /// </summary>
        /// <value>The product description.</value>
        public string ProductDescription
        {
            get
            {
                return this.productDescription;
            }

            set
            {
                this.productDescription = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the product icon.
        /// </summary>
        /// <value>The product icon.</value>
        public string ProductIcon
        {
            get
            {
                return this.productIcon;
            }

            set
            {
                this.productIcon = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the product version.
        /// </summary>
        /// <value>The product version.</value>
        public string ProductVersion
        {
            get
            {
                return this.productVersion;
            }

            set
            {
                this.productVersion = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        /// <value>The employee details.</value>
        public ObservableCollection<AboutUsModel> EmployeeDetails { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        private void ItemSelected(object selectedItem)
        {
            // Do something
        }

        #endregion
    }
}