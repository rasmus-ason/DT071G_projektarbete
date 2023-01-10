using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FlagQuiz.Models;

namespace FlagQuiz.DataServices
{
    public class RestDataService : IRestDataService
    {

        //Declare http-client
        private readonly HttpClient _httpClient;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        List<Flags> flags = new List<Flags>();

        //Constructor
        public RestDataService()
        {
            //Use to connect to API
            _httpClient = new HttpClient();
            _url = "https://cdn.jsdelivr.net/npm/country-flag-emoji-json@2.0.0/dist/index.json";

            //Specify the use of camelcase in get-req, not sure if needed?
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<List<Flags>> GetAllFlagsAsync()
        {
            //If internet connection fails
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access!");
                return flags;
            }

            
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_url);

                //When response is ok
                if (response.IsSuccessStatusCode)
                {
                    //Get content of response
                    string content = await response.Content.ReadAsStringAsync();

                    //Deserialize and store in flags - _jsonSerializerOptions specifies the use of camelcase
                    flags = JsonSerializer.Deserialize<List<Flags>>(content, _jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine("----> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }

            return flags;
        }

       




    }
}
