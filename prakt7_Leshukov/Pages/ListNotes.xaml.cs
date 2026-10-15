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

        public ListNotes ()
        {
            InitializeComponent( );
          
            DataContext = this;
        }
       
        private async void GetAll (object sender, RoutedEventArgs e)
        {

            await service.GetAllFunc( );
            events = service.events;
        }

        private async void GetAllFilter (object sender, RoutedEventArgs e)
        {

            

        }
    }
}
