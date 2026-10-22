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
using prakt7_Leshukov.Services;

namespace prakt7_Leshukov.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListNotes.xaml
    /// </summary>
    public partial class ListNotes :Page
    {
        public ObservableCollection<Event> events { get; set; } = new ObservableCollection<Event>( );
        private ServiceEvents service = new ServiceEvents( );
        public string location=null;
        public int id;
        
        public bool? isActive = null;
        public ListNotes ()
        {
            InitializeComponent( );

            grid.DataContext = this;
        }

        private async void GetAll (object sender, RoutedEventArgs e)
        {
            var data = await service.GetAllFunc(location, isActive);
            events.Clear( );
            foreach (var item in data)
                events.Add(item);
        }

        private async void GetAllFilter (object sender, RoutedEventArgs e)
        {

            var data = await service.GetAllFunc(location, isActive);
            events.Clear( );
            foreach (var item in data)
                events.Add(item);
            
        }

        private void Go_to_add (object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add() );
        }
        private void Delete (object sender, RoutedEventArgs e)
        {
            del_add.DataContext = id;
            service.Delete(id);
        }
    }
}
