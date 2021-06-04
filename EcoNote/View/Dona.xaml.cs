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
    /// Dona.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Dona : Page
    {
        public Dona()
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



        private void Button_Click_1(object sender, RoutedEventArgs e) //로고
        {
            NavigationService.Navigate(new Uri("/view/Main.xaml", UriKind.Relative));
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            int r2 = new Random().Next(1000);
            int random = r2;

            //db donation table insert
            if (int.Parse(textboxc.Text) < int.Parse(money.Text))
                MessageBox.Show("기부금이 보유금보다 많습니다.");
            else
            {
                try
                {
                    MySqlConnection cc = new MySqlConnection("Server=localhost;Database=econote;UId=root;Password=5458;");
                    MySqlCommand comm = new MySqlCommand();
                    cc.Open();

                    comm.CommandText = "INSERT INTO Donation(dNum, dUserId, dMoney) VALUES (@dNum, @dUserId, @dMoney)";

                    comm.Parameters.Add("@dNum", MySqlDbType.Text).Value = r2;
                    comm.Parameters.Add("@dUserId", MySqlDbType.Text).Value = textboxid.Text;
                    comm.Parameters.Add("@dMoney", MySqlDbType.Text).Value = money.Text;


                    comm.Connection = cc;

                    comm.ExecuteNonQuery();
                    cc.Close();

                    MessageBox.Show("기부되었습니다.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류.");
                }

                //세션으로 넘겨받은 상단 textbox값도 감소시키기
                int a = int.Parse(textboxc.Text) - int.Parse(money.Text);
                textboxc.Text = a.ToString();

                //user의 totalC에서 기부금만큼 감소시키기

                string connectionsString3 = @"server=localhost;userid=root;password=5458;database=econote";
                MySqlConnection connection = null;
                try
                {
                    connection = new MySqlConnection(connectionsString3);
                    connection.Open();


                    MySqlCommand cmd5 = new MySqlCommand();
                    cmd5.Connection = connection;


                    cmd5.CommandText = "UPDATE user SET  uTotalC = uTotalC - " + this.money.Text + " WHERE uId='" + this.textboxid.Text + "';";


                    cmd5.ExecuteNonQuery();


                }
                finally
                {
                    if (connection != null)
                        connection.Close();


                }
            }



            ////////////////////////////////////////////////////////////////////////////////////

            // Donation테이블에서 uid== 해당아이디인 행의 dMoney의 합으로 누적기부금 구하기


            //////Donation 해당아이디와 Uid같은 행들을 리스트화
            string conString = "Server=localhost;Database=EcoNote;UId=root;Password=5458;";
            MySqlConnection con = new MySqlConnection(conString);
            MySqlCommand command = new MySqlCommand("select * from donation where dUserId = '" + textboxid.Text + "';", con);
            con.Open();
            DataTable dtG = new DataTable();
            dtG.Load(command.ExecuteReader());
            List<Donation> donations = dtG.DataTableToList<Donation>();

            int sumM = donations.Sum((x) => x.dMoney);


            con.Close();




            //누적 기부금 txtbox에 넣어주기
            totalMoney.Text = sumM.ToString();


            /////////user의 기부금 누적기부금에 update해주기
            string connectionsString = @"server=localhost;userid=root;password=5458;database=econote";
            MySqlConnection connectiona = null;
            try
            {
                connectiona = new MySqlConnection(connectionsString);
                connectiona.Open();


                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connectiona;


                cmd.CommandText = "UPDATE user SET uTotalD = uTotalD + " +sumM + " WHERE uId='" + this.textboxid.Text + "';";


                cmd.ExecuteNonQuery();


            }
            finally
            {
                if (connectiona != null)
                    connectiona.Close();


            }










        }
    }
}
