using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CoronaDoctor.Data
{
    public static class Constants
    {

        public const string ALL_CORONA_STATES_END_POINT = "https://corona.lmao.ninja/all";
        public const string CORONA_AFFECTED_COUNTRIES_ENDPOINT = "https://corona.lmao.ninja/countries";
        public const  string AppUrl = "https://hnicolus.github.io/My-Portfolio/com.nCovidUpdates.CovidDoctor.apk";

        public static string AppId
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// These Ids are test Ids from https://developers.google.com/admob/android/test-ads
        /// </summary>
        /// <value>The banner identifier.</value>
        public static string BannerId
        {
            //ca-app-pub-5780847061911787/5652254841
//           

            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// These Ids are test Ids from https://developers.google.com/admob/android/test-ads
        /// </summary>
        /// <value>The Interstitial Ad identifier.</value>
        public static string InterstitialAdId
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "";
                    default:
                        return "";
                }
            }
        }

        public static bool ShowAds
        {
            get
            {
                _adCounter++;
                if (_adCounter % 5 == 0)
                {
                    return true;
                }
                return false;
            }
        }

        private static int _adCounter;


    }
}
