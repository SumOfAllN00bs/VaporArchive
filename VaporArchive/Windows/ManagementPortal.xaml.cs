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
using System.Data.Entity;
using System.ComponentModel;

namespace VaporArchive
{
    /// <summary>
    /// Interaction logic for ManagementPortal.xaml
    /// </summary>
    public partial class ManagementPortal : Window
    {
        //Archive Root = new Archive();
        ArchiveDatabaseContext _archive = new ArchiveDatabaseContext();
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
            CollectionViewSource gameViewSource = ((CollectionViewSource)(this.FindResource("gameViewSource")));
            if (gameViewSource == null)
            {
                MessageBox.Show("Error: gameviewsource is null");
            }
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
            _archive.Games.Load();
            gameViewSource.Source = _archive.Games.Local;

            UpdateView();
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

        private void btn_SaveChanges_Click(object sender, RoutedEventArgs e)
        {

            _archive.SaveChanges();
            dg_Games.Items.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _archive.Dispose();
        }
    }
}
