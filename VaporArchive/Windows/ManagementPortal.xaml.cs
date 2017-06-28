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
using System.Windows.Shapes;

namespace VaporArchive
{
    /// <summary>
    /// Interaction logic for ManagementPortal.xaml
    /// </summary>
    public partial class ManagementPortal : Window
    {
        Archive Root = new Archive();
        public ManagementPortal()
        {
            InitializeComponent();
        }

        private void btn_MyAccount_Click(object sender, RoutedEventArgs e)
        {
            MyAccount ma = new MyAccount();
            Application.Current.MainWindow = this;
            ma.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (Application.Current.Properties["AccountType"].ToString())
            {
                case "Customer":
                    break;
                case "Submitter":
                    break;
                case "SysAdmin":
                    break;
                default:
                    break;
            }
            UpdateView();
            System.Windows.Data.CollectionViewSource gameViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("gameViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            gameViewSource.Source = new Database().GetGames();
        }
        public void UpdateView()
        {
            if (Application.Current.Properties.Contains("Username"))
            {
                lbl_Welcome.Content = "Welcome: " + Application.Current.Properties["Username"];
            }
            else
            {
                MessageBox.Show("Login Error: missing login info");
                Application.Current.Shutdown();
            }
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Logout();
        }
        public void Logout()
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Application.Current.Properties.Remove("Username");
            Application.Current.Properties.Remove("AccountType");
            Application.Current.MainWindow = mw;
            Close();
        }
    }
}
