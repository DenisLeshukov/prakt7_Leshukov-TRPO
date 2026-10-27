using prakt7_Leshukov.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xaml.Schema;

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
        public async Task<List<Event>> GetAll(string? location,bool? isActive)
        {
            events.Clear();
            try
            {

            
                string currentUri = "api/Events";
                if(!string.IsNullOrEmpty(location) && isActive != null)
                {
                    currentUri += $"?location={location}&isActive={isActive.ToString().ToLower()}";
                }
                if(location == null && isActive != null)
                {
                    currentUri += $"?isActive={isActive.ToString().ToLower()}";
                }
                if(!string.IsNullOrEmpty(location) && isActive == null)
                {
                    currentUri += $"?location={location}";
                }
           
                var response = await httpClient.GetFromJsonAsync<List<Event>>(currentUri);
            
                return response;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("API сервер недоступен, либо ваш запрос неверен");
            }
            catch
            {
                MessageBox.Show("Неверные данные");
            }
            return null;
        }
        public async Task<Event> GetOne(int id)
        {
            try
            {
                events.Clear();
                var response = await httpClient.GetFromJsonAsync<Event>($"api/Events/{id}");

                return response;

            }
            catch (HttpRequestException)
            {
                MessageBox.Show("API сервер недоступен, либо ваш запрос неверен");
            }
            return null;
        }
        public async Task Create(Event ev)
        {
            var response = await httpClient.PostAsJsonAsync("api/Events", ev);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Неверные данные");
            }
            

        }
        public async Task Delete(int id)
        {
            var response = await httpClient.DeleteAsync($"api/Events/{id}");



        }
        public async Task Change(int id, Event ev)
        {
            var response = await httpClient.PutAsJsonAsync($"api/Events/{id}", ev);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Неверные данные");
            }

        }
        public async Task ChangeSome(int id, EventPatch ev)
        {
            var response = await httpClient.PatchAsJsonAsync($"api/Events/{id}", ev);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Неверные данные");
            }

        }
    }
}
