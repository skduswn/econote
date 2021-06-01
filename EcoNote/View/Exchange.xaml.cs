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
    /// Exchange.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Exchange : Page
    {
        public Exchange()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e) //로고
        {
            NavigationService.Navigate(new Uri("/view/Main.xaml", UriKind.Relative));
        }
    }
}
