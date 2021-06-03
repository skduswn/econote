
using EcoNote.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

            this.DataContext = this;

            //user table list화 하기
            string connectionString = "Server=localhost;Database=econote;UId=root;Password=5458;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from user", connection);
            connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            List<User> Users = dt.DataTableToList<User>();


            //uId session값 textbox에 넣기
            //uTotalC session 값 textbox에 넣기
            User user = Users.Single((x) => x.uId.ToString() == (string)Application.Current.Properties["loginID"]);
            textboxid.Text = user.uId.ToString();
            textboxc.Text = user.uTotalC.ToString();

            connection.Close();

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
            NavigationService.Navigate(new Uri("/View/Dona.xaml", UriKind.Relative));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) //교환으로
        {
            NavigationService.Navigate(new Uri("/View/Exch.xaml", UriKind.Relative));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) //교환권으로
        {
            NavigationService.Navigate(new Uri("/View/Showgift.xaml", UriKind.Relative));
        }
    }
}
