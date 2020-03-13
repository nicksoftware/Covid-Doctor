using CoronaDoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaDoctor.ViewModels
{
    class DiagnosisViewModel
    {
        public ICollection<CheckItem> CheckingList { get; set; }

        public DiagnosisViewModel()
        {
            CheckingList = new List<CheckItem>()
            {
                new CheckItem(){ Title = "I am coughing", Detail= "Are you having a bad cough ?If you have been coughing please let the system know by checking the box"},
                new CheckItem(){Title = "I have fever", Detail = "Expriencing a cold chill ? Pleae check the box" },
                new CheckItem(){Title = "I have a dry throat",Detail = "Feeling dry in your throat" },
                new CheckItem(){Title = "I am sneezing",Detail = "have you been sneezing alot?" },
                new CheckItem(){Title = "I have chest pains",Detail = "if you have pains in you chest,nCovid is a respitory diease" },
                new CheckItem(){Title = "I have been to Italy",Detail = "Have you travelled to Italy recently" },
                new CheckItem(){Title = "I Feeling like am drowning",Detail = "nCovid Virus courses your lungs to get filled with fluids" },
                new CheckItem(){Title = "I have a sore throat", Detail = "Expriencing sore pains in your throat?" },
                 new CheckItem(){Title = " I feel like I can't breath",Detail = "nCovid Virus courses your lungs to get filled with fluids" },
                new CheckItem(){Title = "I have been to China",Detail = "Have you travelled to china recently" },
                new CheckItem(){Title = "I have recently travelled internationally", Detail = "If you have travelled internationlly let us know." },
                new CheckItem(){Title = "I have been in Contact with someone with Corona" ,Detail = "If you have been exposed to the virus lets us know." },
                new CheckItem(){Title = "I am expriencing breath shortness", Detail = "If you having problems breathing please check the box." },
            };
        }


        public  string GetDiagnosis(int NumberOfChecked)
        {

            int itemsCount = CheckingList.Count();

            double percentage =  Average(NumberOfChecked, itemsCount);

            if (percentage <= 49)
            {
                return "You Do not have Corona Virus";

            }
            else if (percentage > 49 && percentage <= 69)
            {
                return $"There is a {percentage}% chance that you might be ill ,you Should consult a doctor";

            }
            else if (percentage > 69 && percentage <= 100)
            {
                if(percentage > 80)
                {
                    return $"You NEED TO VISIT A DOCTOR URGENTLY, you symptoms are {percentage}% similar to those of the nCov-19 virus symptoms there is a great chance that you might have contracted nCov-19.";
                }
                return $"You are not well you need to see a doctor.There is a {percentage}% that you might be sink.";
            }
            else
            {
                return " Hmmm there seems to be an error with the given data";
            }
        }


        private double Average(int numberOfCheckedItems, int numberOfListItems)
        {

            var answer = decimal.Divide(numberOfCheckedItems, numberOfListItems) * 100;
            return (double) answer;
        }
    }
}
