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
    /// Interaction logic for RegisterAccount.xaml
    /// </summary>
    public partial class RegisterAccount : Window
    {
        public RegisterAccount()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_CreateNewAccount_Click(object sender, RoutedEventArgs e)
        {
            if (!Helper.CheckValidText(txt_UserName.Text, "username"))
            {
                MessageBox.Show("Failed");
                return;
            }
            if (!Helper.CheckValidText(pwd_Password.Password, "password"))
            {
                MessageBox.Show("Failed");
                return;
            }
            Database db = new Database();
            int acctype = -1;
            acctype = (rb_Customer.IsChecked ?? false) ? 1 : acctype;
            acctype = (rb_Submitter.IsChecked ?? false) ? 2 : acctype;
            if (!db.CreateAccount(txt_UserName.Text, pwd_Password.Password, acctype)) MessageBox.Show("Failed to create account");
            else
            {
                MessageBoxResult MBResult = MessageBox.Show("If you want to create another account press ok, otherwise to login press cancel", "Done creating account?", MessageBoxButton.OKCancel);
                if (MBResult == MessageBoxResult.Cancel)
                {
                    Close();
                }
            }
        }
    }
}
