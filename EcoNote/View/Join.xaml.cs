using MySql.Data.MySqlClient;
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
    /// Join.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Join : Page
    {
        public Join()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view/Home.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //회원가입 성공시 로그인화면으로
        {
            //모든 정보 입력하도록
            if (string.IsNullOrEmpty(textbox1.Text))
            {
                MessageBox.Show("이름을 입력해주세요");
                this.textbox1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textbox2.Text))
            {
                MessageBox.Show("전화번호를 입력해주세요");
                this.textbox2.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textbox3.Text))
            {
                MessageBox.Show("아이디를 입력해주세요");
                this.textbox3.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textbox4.Text))
            {
                MessageBox.Show("비밀번호를 입력해주세요");
                this.textbox4.Focus();
                return;
            }


            //db user table insert
            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=econote;UId=root;Password=5458;");
                MySqlCommand comm = new MySqlCommand();
                conn.Open();

                comm.CommandText = "INSERT INTO USER(uName, uPNum, uId, uPwd) VALUES (@uName, @uPNum, @uId, @uPwd)";

                comm.Parameters.Add("@uName", MySqlDbType.Text).Value = textbox1.Text;
                comm.Parameters.Add("@uPNum", MySqlDbType.Text).Value = textbox2.Text;
                comm.Parameters.Add("@uId", MySqlDbType.Text).Value = textbox3.Text;
                comm.Parameters.Add("@uPwd", MySqlDbType.Text).Value = textbox4.Text;

                comm.Connection = conn;

                comm.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("회원가입 되었습니다.");
                NavigationService.Navigate(new Uri("/view/Login.xaml", UriKind.Relative));
            }
            catch (Exception ex)
            { 
                MessageBox.Show("아이디가 중복 되었습니다."); }
               
            }

       
    }
}
