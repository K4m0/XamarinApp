using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Android.Provider;
using Newtonsoft.Json;
using XamarinExam.Model.Entities;
using System.Diagnostics;
using Microsoft.WindowsAzure.MobileServices.Query;
using Newtonsoft.Json.Linq;

namespace XamarinExam.Model.Services
{
    public class RestService
    {
        private static HttpClient client;

        public static HttpClient Client => client ?? (client = new HttpClient());

        protected string BaseUrl { get; set; } = "https://itunes.apple.com/us/rss/topfreeapplications/limit=10/genre=6018/json";

        public ObservableCollection<IMaterial> Materials { get; private set; }

        public RestService()
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            //Client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ObservableCollection<TopFreeApp>> RefreshDataAsyncApp()
        {
            TopFreeApp topFreeApp = new TopFreeApp();
            ObservableCollection<TopFreeApp> TopFreeApps = new ObservableCollection<TopFreeApp>();
            try
            {
                var CompleteUrl = BaseUrl;

                var response = await Client.GetAsync(CompleteUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject o = JObject.Parse(content);
                    for (int i = 0; i < o["feed"]["entry"].Children().Count(); i++)
                    {
                        topFreeApp.Title = o["feed"]["entry"][i]["title"]["label"].ToString();
                        topFreeApp.Link = o["feed"]["entry"][i]["link"]["attributes"]["href"].ToString();
                        topFreeApp.Category = o["feed"]["entry"][i]["category"]["attributes"]["label"].ToString();
                        topFreeApp.ReleaseDate = o["feed"]["entry"][i]["im:releaseDate"]["attributes"]["label"].ToString();

                        TopFreeApps.Add(topFreeApp);
                    }

                    
                   

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
                

            }
            return  TopFreeApps;
        }

        public async Task<RequestResult<TResponseType>> RefreshDataAsync<TResponseType>(string url)
        {
            try
            {
                var CompleteUrl = BaseUrl + url;

                var response = await Client.GetAsync(CompleteUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                   
                    //var content = await response.Content.ReadAsStringAsync();
                    //RootObject rootObject = new RootObject();
                    //var result = JsonConvert.DeserializeObject<RootObject>(content);

                    //  TResponseType result = JsonConvert.DeserializeObject<TResponseType>(content);
                    //return new RequestResult<TResponseType>(response) { Data = result };
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return new RequestResult<TResponseType>(null);
        }


        public async Task<RequestResult> SaveTodoItemAsync<TDataParamType>(TDataParamType item, string url)
        {
            var uri = new Uri(string.Format(BaseUrl + url, item));

            var json = JsonConvert.SerializeObject(item);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            try
            {
                response = await Client.PutAsync(uri, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return new RequestResult(response) { Data = response.RequestMessage };

        }

        public async Task<RequestResult> DeleteTodoItemAsync<TDataParamType>(string url, string id)
        {
            var uri = new Uri(string.Format(BaseUrl + url, id));

            HttpResponseMessage response = await Client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"				TodoItem successfully deleted.");

            }
            return new RequestResult(response) { Data = response.RequestMessage };

        }

    }
}
