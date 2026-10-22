using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

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
        public async Task<List<Event>> GetAllFunc (string? location, bool? isActive)
        {
            var query = new List<string>( );
            if (!string.IsNullOrWhiteSpace(location))
                query.Add($"location={Uri.EscapeDataString(location)}");
            if (isActive.HasValue)
                query.Add($"isActive={isActive.Value}");

            string response_url = "api/Events";
            if (query.Count > 0)
                response_url += "?" + string.Join("&", query);

            var response = await httpClient.GetFromJsonAsync<List<Event>>(response_url);
            return response ?? new List<Event>( );

        }
        public async Task Create(Event ev)
        {
            var response = await httpClient.PostAsJsonAsync("api/Events", ev);


        }
        public async Task Delete(int id)
        {
            var response = await httpClient.DeleteAsync($"api/Events/{id}");



        }
    }
}
