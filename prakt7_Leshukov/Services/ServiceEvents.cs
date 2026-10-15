using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace prakt7_Leshukov.Services
{
    public class ServiceEvents
    {
        HttpClient httpClient = new HttpClient();
        public ObservableCollection<Event> events { get; set; } = new ObservableCollection<Event>();
        public ServiceEvents()
        {
            httpClient.BaseAddress = new Uri("https://localhost:7062/");
        }
        public async Task GetAllFunc()
        {
            var response = await httpClient.GetFromJsonAsync<List<Event>>("api/Events");
            if (response != null)
            {
                foreach (var item in response)
                {
                    events.Add(item);
                }
            }
        }
    }
}
