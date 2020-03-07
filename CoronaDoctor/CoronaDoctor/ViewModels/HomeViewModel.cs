using CoronaDoctor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaDoctor.ViewModels
{


    class HomeViewModel
    {
        public ICollection<NavigationItem> NavItemsList { get; set; }

        public HomeViewModel()
        {
            NavItemsList = new List<NavigationItem>()
            {
                new NavigationItem(){ Title="Do Self Diagnosis",  Detail="if you not well"},
                new NavigationItem(){ Title="Learn About Corona",  Detail="Be well informed"},
                new NavigationItem(){ Title="Areas Affected by Corona",  Detail="Maps"},
                new NavigationItem(){ Title="Contact a Doctor",  Detail="if you not well"}
            };
        }
    }
}
