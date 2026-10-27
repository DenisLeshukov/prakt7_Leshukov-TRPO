using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using prakt7_Leshukov.Models;
using prakt7_Leshukov.Services;

namespace prakt7_Leshukov.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListNotes.xaml
    /// </summary>
    public partial class ListEvents :Page
    {
        public ObservableCollection<Event> events { get; set; } = new ObservableCollection<Event>( );
        private ServiceEvents service = new ServiceEvents( );
        public string location { get; set; }
        public string id { get; set; }
        public string idGet { get; set; }
        public Event selected { get; set; } = new Event();
        
        public bool? isActive { get; set; }
        public ListEvents ()
        {
            InitializeComponent();

            grid.DataContext = this;
            Refresh();

        }
        public async void Refresh()
        {
            var data = await service.GetAll(null, null);
            events.Clear();
            if(isActive == null)
            {
                data = await service.GetAll(location, null);
            }
            else
            {
                data = await service.GetAll(location, isActive);
            }

            foreach (var i in data)
            {
                events.Add(i);
            }
        }
        private async void GetAll (object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private async void GetAllFilter (object sender, RoutedEventArgs e)
        {

            Refresh();
            
        }

        private void Go_to_add (object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add() );
        }
        private async void Delete (object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(id, out int idDel) || idDel <= 0)
            {
                MessageBox.Show("ID должен быть положительным");
                return;
            }
            try
            {
                await service.Delete(idDel);
                Refresh();
            }
            catch{
                MessageBox.Show("Неверные данные");
            }
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(selected != null)
            {
                NavigationService.Navigate(new Change(selected));
            }
        }

        private async void GetOne(object sender, RoutedEventArgs e)
        {
            events.Clear();
            if (!int.TryParse(idGet, out int idOne) || idOne <= 0)
            {
                MessageBox.Show("ID должен быть положительным");
                return;
            }
            try
            {
                var data = await service.GetOne(idOne);
                events.Add(data);
            }
            catch
            {
                MessageBox.Show("Неверные данные");
            }
            
        }
    }
}
