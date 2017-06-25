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

        //testing
        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (ArchiveDatabaseContext dbContext = new ArchiveDatabaseContext())
            {
                try
                {
                    //create
                    Account acc = new CustomerAccount();

                    //fill in account type independent data
                    acc.AccountCreated = DateTime.Now;
                    var saltedPassword = "vS4n7YQ3eh8vnpAH" + acc.AccountCreated.Ticks.ToString();
                    HMACSHA256 hashed = new HMACSHA256(Helper.GetEncryptionKey());
                    acc.PasswordHash = Convert.ToBase64String(hashed.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
                    acc.UserName = "sysadmin";
                    //add acc to proper table
                    dbContext.Customers.Add((CustomerAccount)acc);

                    dbContext.SaveChanges();

                    //test
                    Account accToTest = (from a in dbContext.Accounts
                                         where a.UserName == "sysadmin"
                                         select a).FirstOrDefault();
                    if (acc == null)
                    {
                        MessageBox.Show("Can't find account or password combination");
                    }
                    else
                    {
                        HMACSHA256 hashed2 = new HMACSHA256(Helper.GetEncryptionKey());
                        var salt2 = "vS4n7YQ3eh8vnpAH" + acc.AccountCreated.Ticks.ToString();
                        var PasswordHashed = Convert.ToBase64String(hashed2.ComputeHash(Encoding.Unicode.GetBytes(salt2)));
                        if (PasswordHashed == accToTest.PasswordHash)
                        {
                            MessageBox.Show("Success");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
