using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Syncfusion.DataSource;
using System.Globalization;
using CoronaDoctor.Models.CoronaData;

namespace CoronaDoctor.Behaviors.Countries
{
    /// <summary>
    /// This class extends the behavior of SfListView control to group the contact names list in alphabetical order.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CountriesListViewBehavior : Behavior<Syncfusion.ListView.XForms.SfListView>
    {
        #region Fields

        private Syncfusion.ListView.XForms.SfListView listView;

        #endregion

        #region Overrides
        /// <summary>
        /// Invoked when adding the SfListView to view.
        /// </summary>
        /// <param name="bindable">The SfListView</param>

        protected override void OnAttachedTo(Syncfusion.ListView.XForms.SfListView bindable)
        {
            listView = bindable;
            listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "Country",
                KeySelector = (object obj1) =>
                {
                    var item = (obj1 as CountryData);
                    return item.Country[0].ToString(CultureInfo.CurrentCulture);
                },
            });
            base.OnAttachedTo(bindable);
        }

        /// <summary>
        /// Invoked when the list view is detached. 
        /// </summary>
        /// <param name="bindable">The SfListView</param>

        protected override void OnDetachingFrom(Syncfusion.ListView.XForms.SfListView bindable)
        {
            listView = null;
            base.OnDetachingFrom(bindable);
        }

        #endregion
    }
}