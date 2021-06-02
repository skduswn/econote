
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
    /// Note.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Note : Page
    {
        public Note()
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

        private void Button_Click_1(object sender, RoutedEventArgs e)   //메인으로
        {
            NavigationService.Navigate(new Uri("/view/Main.xaml", UriKind.Relative));
        }

        private void Button_Click2(object sender, RoutedEventArgs e)   //자전거 버튼 
        {
            textbox1.Text = "자전거";
        }

        private void Button_Click3(object sender, RoutedEventArgs e)    //달리기 버튼
        {
            textbox1.Text = "달리기";
        }

        private void Button_Click4(object sender, RoutedEventArgs e)   //걷기 버튼
        {
            textbox1.Text = "걷기";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)  //기록하기 버튼
        {
            //모든 정보 입력하도록
            if (string.IsNullOrEmpty(textbox1.Text))
            {
                MessageBox.Show("종류를 선택해주세요");
                this.textbox1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textbox2.Text))
            {
                MessageBox.Show("이동거리를 입력해주세요");
                this.textbox2.Focus();
                return;
            }

            int carbon = int.Parse(textbox2.Text) * 21;

            int r2 = new Random().Next(1000);
            int random = r2;

            //db move table insert
            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=econote;UId=root;Password=5458;");
                MySqlCommand comm = new MySqlCommand();
                conn.Open();

                comm.CommandText = "INSERT INTO Move(mNum, mUserId, mWay, mDistance, mCarbonRA) VALUES (@mNum, @mUserId, @mWay, @mDistance, @mCarbonRA)";

                comm.Parameters.Add("@mNum", MySqlDbType.Text).Value = r2;
                comm.Parameters.Add("@mUserId", MySqlDbType.Text).Value = textboxid.Text;
                comm.Parameters.Add("@mWay", MySqlDbType.Text).Value = textbox1.Text;
                comm.Parameters.Add("@mDistance", MySqlDbType.Text).Value = textbox2.Text;
                comm.Parameters.Add("@mCarbonRA", MySqlDbType.Text).Value = carbon;

                

                comm.Connection = conn;

                comm.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("기록되었습니다.");
            
            }
            catch (Exception ex)
            { MessageBox.Show("예외오류처리"); }





            //탄소감소량 user의 코인에 업데이트
            string connectionsString = @"server=localhost;userid=root;password=5458;database=econote";
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectionsString);
                connection.Open();
  

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

               
                cmd.CommandText = "UPDATE user SET uTotalC = uTotalC + " + carbon + " WHERE uId='" + this.textboxid.Text + "';";

               
                cmd.ExecuteNonQuery();
              

            }
            finally
            {
                if (connection != null)
                    connection.Close();

           
            }


            //업데이트된 값 textboxc에 넣기

            string connectionString = "Server=localhost;Database=econote;UId=root;Password=5458;";
            MySqlConnection connection1 = new MySqlConnection(connectionString);
            MySqlCommand cmd1 = new MySqlCommand("select * from user", connection1);
            connection1.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd1.ExecuteReader());
            List<User> Users1 = dt.DataTableToList<User>();

            User user = Users1.Single((x) => x.uId.ToString() == (string)Application.Current.Properties["loginID"]);
            textboxc.Text = user.uTotalC.ToString();


            connection1.Close();

        }
    }
}
