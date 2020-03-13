using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace CoronaDoctor.Models.AboutUs
{
 
    [Preserve(AllMembers = true)]
    public class AboutUsModel : INotifyPropertyChanged
    {
        #region Fields

        public string EmployeeName { get; set; }

        public string BackgroundHistory { get; set; }

        public string WebSiteUrl { get; set; }

        public bool HasWebSite { get; set; }

        private string designation;

        private string image;

        #endregion

        #region EventHandler

 
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public string Designation
        {
            get
            {
                return this.designation;
            }

            set
            {
                this.designation = value;
                this.OnPropertyChanged(nameof(Designation));
            }
        }

        public string Image
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
                this.OnPropertyChanged(nameof(Image));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
