﻿using System;
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
    /// Login.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)   //로고
        {
            NavigationService.Navigate(new Uri("/view/Home.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //로그인
        {
            NavigationService.Navigate(new Uri("/view/Main.xaml", UriKind.Relative));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)  //회원가입
        {
            NavigationService.Navigate(new Uri("/view/Join.xaml", UriKind.Relative));
        }
    }
}
