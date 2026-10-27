using prakt7_Leshukov.Models;
using prakt7_Leshukov.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        private Event _ev = new Event( );
       
        private ServiceEvents service = new ServiceEvents( );
        public Add()
        {
            InitializeComponent();
            DataContext = _ev;
        }

        private async void AddEvent (object sender, RoutedEventArgs e)
        {
            try
            {
                await service.Create(_ev);
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
