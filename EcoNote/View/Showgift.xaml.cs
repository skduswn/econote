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
    /// Showgift.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Showgift : Page
    {
        public Showgift()
        {
            InitializeComponent();
            this.DataContext = this;

            //초기화시 아이디 뜨도록
            //user table list화 하기
            string connectionString = "Server=localhost;Database=econote;UId=root;Password=5458;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from user", connection);
            connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            List<User> Users = dt.DataTableToList<User>();

            User user = Users.Single((x) => x.uId.ToString() == (string)Application.Current.Properties["loginID"]);
            textboxid.Text = user.uId.ToString();


            //데이터 그리드에 해당아이디의 교환권 이력 정보 뜨도록
            //꺼낼 테이블 list화 하기
            string connectionString1 = "Server=localhost;Database=econote;UId=root;Password=5458;";
            MySqlConnection connection1 = new MySqlConnection(connectionString1);
            MySqlCommand cmd1 = new MySqlCommand("select * from exchange where eUserid = '" + textboxid.Text + "';", connection1);
            connection1.Open();
            DataTable dt1 = new DataTable();
            dt1.Load(cmd1.ExecuteReader());
            List<Exchange> exchanges = dt1.DataTableToList<Exchange>();


            dtGrid.DataContext = exchanges;
            connection1.Close();




        }

        private void Button_Click(object sender, RoutedEventArgs e)  //로고
        {
            NavigationService.Navigate(new Uri("/View/Main.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //교환 취소 버튼
        {

            //해당 셀 교환 테이블에서 삭제

            //상품 재고 올리기

            //user의 코인 값 올리기

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //셀 선택시 각 정보 텍스트 박스에 넘어가도록
        }
    }
}
