using prakt7_Leshukov.Models;
using prakt7_Leshukov.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prakt7_Leshukov.Pages
{
    /// <summary>
    /// Логика взаимодействия для Change.xaml
    /// </summary>
    public partial class Change : Page
    {
        public Event curEvent { get; set; }
        public Event origEvent { get; set; }
       
        public ServiceEvents service { get; set; } = new ServiceEvents();
        public Change(Event selected)
        {
            InitializeComponent();
            curEvent = selected;
            origEvent = new Event
            {
                Id = selected.Id,
                Title = selected.Title,
                Location = selected.Location,
                EventDate = selected.EventDate,
                TicketPrice = selected.TicketPrice,
                IsActive = selected.IsActive
            };
            DataContext = curEvent;
        }

        private async void ChangeItem(object sender, RoutedEventArgs e)
        {
            EventPatch patch = new EventPatch();

            if (curEvent.Title != origEvent.Title)
                patch.Title = curEvent.Title;

            if (curEvent.Location != origEvent.Location)
                patch.Location = curEvent.Location;

            if (curEvent.EventDate != origEvent.EventDate)
                patch.EventDate = curEvent.EventDate;

            if (curEvent.TicketPrice != origEvent.TicketPrice)
                patch.TicketPrice = curEvent.TicketPrice;

            if (curEvent.IsActive != origEvent.IsActive)
                patch.IsActive = curEvent.IsActive;

            if (patch.Title == null && patch.Location == null && patch.EventDate == null &&
        patch.TicketPrice == null && patch.IsActive == null)
            {
                MessageBox.Show("Нет изменений");
                return;
            }
            try
            {
                await service.ChangeSome(curEvent.Id, patch);

                origEvent = new Event
                {
                    Id = curEvent.Id,
                    Title = curEvent.Title,
                    Location = curEvent.Location,
                    EventDate = curEvent.EventDate,
                    TicketPrice = curEvent.TicketPrice,
                    IsActive = curEvent.IsActive
                };
                MessageBox.Show("Изменено");
                NavigationService.Navigate(new ListEvents());
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("API сервер недоступен, либо ваш запрос неверен");
            }
            catch
            {
                MessageBox.Show("Неверные данные");
            }
        }

        private async void ChangeFullItem(object sender, RoutedEventArgs e)
        {
            
            try
            {
                await service.Change(curEvent.Id,curEvent);
                MessageBox.Show("Сохранено");
                NavigationService.Navigate(new ListEvents());
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("API сервер недоступен, либо ваш запрос неверен");
            }
            catch
            {
                MessageBox.Show("Неверные данные");
            }
        }
    }
}
