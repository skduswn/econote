using System;
using System.Collections.Generic;
using System.Linq;
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

namespace EcoNote.View
{
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)  //메인으로
        {
            NavigationService.Navigate(new Uri("/View/Main.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //기록으로
        {
            NavigationService.Navigate(new Uri("/View/Note.xaml", UriKind.Relative));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //기부로
        {
            NavigationService.Navigate(new Uri("/View/Donation.xaml", UriKind.Relative));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) //교환으로
        {
            NavigationService.Navigate(new Uri("/View/Exchange.xaml", UriKind.Relative));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) //교환권으로
        {
            NavigationService.Navigate(new Uri("/View/Showgift.xaml", UriKind.Relative));
        }
    }
}
