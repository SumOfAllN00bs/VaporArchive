using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace VaporArchive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterAccount CreateNewAccount = new RegisterAccount();
            CreateNewAccount.ShowDialog();
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            if (db.Login(txt_UserName.Text, pwd_Password.Password))
            {
                MessageBox.Show("Success!");
                ManagementPortal mp = new ManagementPortal();
                mp.Show();
                Close();
            }
        }

    }
}
