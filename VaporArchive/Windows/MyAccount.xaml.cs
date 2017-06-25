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
using System.Windows.Shapes;

namespace VaporArchive
{
    /// <summary>
    /// Interaction logic for MyAccount.xaml
    /// </summary>
    public partial class MyAccount : Window
    {
        public MyAccount()
        {
            InitializeComponent();
        }

        private void btn_SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (!Helper.CheckValidText(txt_UserName.Text, "username")) return;
            if (!Helper.CheckValidText(pwd_Password.Password, "password")) return;
            Database db = new Database();
            if (db.AlterAccount(txt_UserName.Text, pwd_Password.Password))
            {
                MessageBox.Show("Success!");
                ((ManagementPortal)Application.Current.MainWindow).UpdateView();
                Close();
            }
            else
            {
                MessageBox.Show("Failed");
            };
        }

        private void btn_DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Are you sure you want to remove your account?, there is no going back!", "Confirmation", MessageBoxButton.YesNoCancel);
            switch (mbr)
            {
                case MessageBoxResult.Cancel:
                    break;
                case MessageBoxResult.Yes:
                    if (MessageBox.Show("Last chance!", "Double Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        MessageBox.Show("Good Choice");
                        break; 
                    }
                    else
                    {
                        Database db = new Database();
                        if (db.RemoveAccount(Application.Current.Properties["Username"].ToString()))
                        {
                            Application.Current.Properties.Remove("Username");
                            ((ManagementPortal)Application.Current.MainWindow).Logout();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Some error occured while deleting account");
                            return;
                        }
                    }
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Good choice");
                    break;
                default:
                    break;
            }
        }
    }
}
