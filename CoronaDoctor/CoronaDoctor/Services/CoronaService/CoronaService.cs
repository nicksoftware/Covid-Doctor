using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using CoronaDoctor.Models.CoronaData;
using Newtonsoft.Json;

namespace CoronaDoctor.Services.CoronaService
{
    class CoronaService
    {
        HttpClient _client;

        public CoronaService()
        {
            _client = new HttpClient();
        }

        public async Task<ObservableCollection<CountryData>> GetCoronaDataAsync(string uri)
        {
            ObservableCollection<CountryData> coronaData = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    coronaData = JsonConvert.DeserializeObject<ObservableCollection<CountryData>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return coronaData;
        }

        public async Task<CoronaStatesData> GetStatesData(string url)
        {
            CoronaStatesData statesData = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync( url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    statesData = JsonConvert.DeserializeObject<CoronaStatesData>(content);

                    
                }
            }catch(Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return statesData;
        }
    }
}
