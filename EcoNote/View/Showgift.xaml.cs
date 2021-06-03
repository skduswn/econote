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

            //초기화시 아이디 뜨도록
            //user table list화 하기
            string connectionString2 = "Server=localhost;Database=econote;UId=root;Password=5458;";
            MySqlConnection connection2 = new MySqlConnection(connectionString2);
            MySqlCommand cmd2 = new MySqlCommand("select * from user", connection2);
            connection.Open();
            DataTable dt2 = new DataTable();
            dt.Load(cmd.ExecuteReader());
            List<User> Users2 = dt.DataTableToList<User>();

            User user2 = Users.Single((x) => x.uId.ToString() == (string)Application.Current.Properties["loginID"]);
            textboxid2.Text = user.uId.ToString();




            //데이터 그리드에 해당아이디의 교환권 이력 정보 뜨도록
            //꺼낼 테이블 list화 하기
            string conString = "Server=localhost;Database=EcoNote;UId=root;Password=5458;";
            MySqlConnection con = new MySqlConnection(conString);
            MySqlCommand command = new MySqlCommand("select * from exchange where eUserid = '" + textboxid.Text + "';", con);
            con.Open();
            DataTable dtG = new DataTable();
            dtG.Load(command.ExecuteReader());
            List<Exchange> exchanges = dtG.DataTableToList<Exchange>();
            con.Close();

            dtGrid.DataContext = exchanges;
            con.Close();









        }

        private void Button_Click(object sender, RoutedEventArgs e)  //로고
        {
            NavigationService.Navigate(new Uri("/View/Main.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //교환 취소 버튼
        {

            //해당 셀 교환 테이블에서 삭제
            string connectionString = @"server=localhost;userid=root;password=5458;database=econote";
            MySqlConnection connection = null;
            try
            {

                connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "delete from exchange where eNum='" + this.eum.Text + "';";
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            MessageBox.Show("취소되었습니다.");


            ////상품 재고 올리기
            string connectionsString0 = @"server=localhost;userid=root;password=5458;database=econote";
            MySqlConnection connection0 = null;
            try
            {
                connection0 = new MySqlConnection(connectionsString0);
                connection0.Open();


                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection0;


                cmd.CommandText = "UPDATE products SET  pStock = pStock +1 WHERE pNum='" + this.num.Text + "';";


                cmd.ExecuteNonQuery();


            }
            finally
            {
                if (connection0 != null)
                    connection0.Close();


            }

            ////user의 코인 값 올리기

            string connectionsString1 = @"server=localhost;userid=root;password=5458;database=econote";
            MySqlConnection connection1 = null;
            try
            {
                connection1 = new MySqlConnection(connectionsString1);
                connection1.Open();


                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection1;


                cmd.CommandText = "UPDATE user SET uTotalC = uTotalC + " + this.price.Text + " WHERE uId='" + this.textboxid.Text + "';";


                cmd.ExecuteNonQuery();


            }
            finally
            {
                if (connection != null)
                    connection.Close();


            }

            //textbox값 올리기
            string connectionString11 = "Server=localhost;Database=econote;UId=root;Password=5458;";
            MySqlConnection connection11 = new MySqlConnection(connectionString11);
            MySqlCommand cmd11 = new MySqlCommand("select * from user", connection11);
            connection11.Open();
            DataTable dt11 = new DataTable();
            dt11.Load(cmd11.ExecuteReader());
            List<User> Users11 = dt11.DataTableToList<User>();

            User user11 = Users11.Single((x) => x.uId.ToString() == (string)Application.Current.Properties["loginID"]);
            textboxc.Text = user11.uTotalC.ToString();


            connection11.Close();


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //셀 선택시 각 정보 텍스트 박스에 넘어가도록
            try
            {

                Exchange myrow = (Exchange)dtGrid.CurrentCell.Item;

                eum.Text = myrow.eNum.ToString();
                num.Text = myrow.ePNum.ToString();
                name.Text = myrow.ePName.ToString();
                price.Text = myrow.ePrice.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("예외처리오류");
            }

        }
    }
}
