
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
    /// Exch.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Exch : Page
    {
        public Exch()
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



        private void Button_Click(object sender, RoutedEventArgs e)  //1인 영화 관람권
        {
            num.Text = "1";
            name.Text = "CGV영화관람권";
            price.Text = "11000";

            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            num.Text = "2";
            name.Text = "CU가나마일드초콜렛";
            price.Text = "1000";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            num.Text = "3";
            name.Text = "교촌허니콤보웨지감자세트";
            price.Text = "23000";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            num.Text = "4";
            name.Text = "던킨모바일금액권";
            price.Text = "10000";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            num.Text = "5";
            name.Text = "설빙망고치즈빙수";
            price.Text = "11900";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            num.Text = "6";
            name.Text = "CU바나나맛우유";
            price.Text = "1400";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            num.Text = "7";
            name.Text = "gs25비타500";
            price.Text = "800";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            num.Text = "8";
            name.Text = "빅맥세트";
            price.Text = "5900";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            num.Text = "9";
            name.Text = "서브웨이모바일금액권";
            price.Text = "11000";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            num.Text = "10";
            name.Text = "스타벅스케이크세트";
            price.Text = "12700";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            num.Text = "11";
            name.Text = "스타벅스아메리카노";
            price.Text = "4100";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            num.Text = "12";
            name.Text = "CU육개장사발면";
            price.Text = "850";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }
        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            num.Text = "13";
            name.Text = "CU초코에몽";
            price.Text = "1000";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }
        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            num.Text = "14";
            name.Text = "CU츄파춥스";
            price.Text = "250";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }
        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            num.Text = "15";
            name.Text = "파리바게트모바일금액권";
            price.Text = "10000";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }
        }
        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            num.Text = "16";
            name.Text = "파인트";
            price.Text = "8200";
            int a = int.Parse(textboxc.Text) - int.Parse(price.Text);
            if (a > 0) { rest.Text = a.ToString(); }
            else { rest.Text = "구매불가"; }

        }

        private void Button_Click_17(object sender, RoutedEventArgs e) //교환하기 버튼
        {

            int r2 = new Random().Next(1000);
            int random = r2;
             
            if (int.Parse(textboxc.Text) < int.Parse(price.Text))    ///보유코인보다 비싸면 구매 불가하도록
                MessageBox.Show("코인이 모자랍니다.");
            else
            {
                
                //교환 테이블 생성

                try
                {
                    MySqlConnection conn = new MySqlConnection("Server=localhost;Database=econote;UId=root;Password=5458;");
                    MySqlCommand comm = new MySqlCommand();
                    conn.Open();

                    comm.CommandText = "INSERT INTO Exchange(eNum, eUserId, ePNum, ePrice, ePName) VALUES (@eNum, @eUserId, @ePNum, @ePrice, @ePName)";

                    comm.Parameters.Add("@eNum", MySqlDbType.Text).Value = r2;
                    comm.Parameters.Add("@eUserId", MySqlDbType.Text).Value = textboxid.Text;
                    comm.Parameters.Add("@ePNum", MySqlDbType.Text).Value = num.Text;
                    comm.Parameters.Add("@ePrice", MySqlDbType.Text).Value = price.Text;
                    comm.Parameters.Add("@ePName", MySqlDbType.Text).Value = name.Text;



                    comm.Connection = conn;

                    comm.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("교환되었습니다.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("교환불가");
                }




                //재고 하나씩 마이너스 --- 상품의 재고량 감소 업데이트
                string connectionsString = @"server=localhost;userid=root;password=5458;database=econote";
                MySqlConnection connection = null;
                try
                {
                    connection = new MySqlConnection(connectionsString);
                    connection.Open();


                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;


                    cmd.CommandText = "UPDATE products SET  pStock = pStock -1 WHERE pNum='" + this.num.Text + "';";


                    cmd.ExecuteNonQuery();


                }
                finally
                {
                    if (connection != null)
                        connection.Close();


                }


                //교환한 코인만큼 user의 totalC 감소
                string connectionsString1 = @"server=localhost;userid=root;password=5458;database=econote";
                MySqlConnection connection1 = null;
                try
                {
                    connection1 = new MySqlConnection(connectionsString1);
                    connection1.Open();


                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection1;


                    cmd.CommandText = "UPDATE user SET uTotalC = uTotalC - " + this.price.Text + " WHERE uId='" + this.textboxid.Text + "';";


                    cmd.ExecuteNonQuery();


                }
                finally
                {
                    if (connection != null)
                        connection.Close();


                }



                //상단 텍스트 상자 coin감소
                string connectionString2 = "Server=localhost;Database=econote;UId=root;Password=5458;";
                MySqlConnection connection2 = new MySqlConnection(connectionString2);
                MySqlCommand cmd1 = new MySqlCommand("select * from user", connection2);
                connection2.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd1.ExecuteReader());
                List<User> Users1 = dt.DataTableToList<User>();

                User user = Users1.Single((x) => x.uId.ToString() == (string)Application.Current.Properties["loginID"]);
                textboxc.Text = user.uTotalC.ToString();


                connection1.Close();






            }
        }

    }

}
