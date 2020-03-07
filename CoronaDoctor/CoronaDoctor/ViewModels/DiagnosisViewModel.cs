using CoronaDoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoronaDoctor.ViewModels
{
    class DiagnosisViewModel
    {
        public ICollection<CheckItem> CheckingList { get; set; }

        public DiagnosisViewModel()
        {
            CheckingList = new List<CheckItem>()
            {
                new CheckItem(){Detail = "I am coughing"},
                new CheckItem(){Detail = "I have fever"},
                new CheckItem(){Detail = "I am sneezing"},
                new CheckItem(){Detail = "I have a sore throat"},
                new CheckItem(){Detail = "I have been to China"},
                new CheckItem(){Detail = "I have recently travelled internationally"},
                new CheckItem(){Detail = "I have been in Contact with someone with Corona"},
                new CheckItem(){Detail = "I am expriencing breath shortness"},
            };
        }


        public string GetDiagnosis(int NumberOfChecked)
        {

            var numberOfCheckedItems = NumberOfChecked;


            var percentage = Average(numberOfCheckedItems, CheckingList.Count())*100;

            if(percentage >= 0 && percentage <= 49)
            {
                return "You Do not have Corona Virus";

            }else if(percentage >= 50 && percentage <= 69)
            {
                return "You Should consult a doctor";

            }else if(percentage >= 70 && percentage <= 100)
            {
                return $"The chances of you having Corona are at {percentage} you need to consult";
            }
            else
            {
                return " Hmmm there seems to be an error with the given data";
            }
        }


        private double Average(int numberOfCheckedItems, int numberOfListItems)
        {
            return (numberOfCheckedItems / numberOfListItems);
        }
    }
}
