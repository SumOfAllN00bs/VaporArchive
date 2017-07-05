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
using System.Collections.ObjectModel;

namespace VaporArchive
{
    /// <summary>
    /// Interaction logic for ManagementPortal.xaml
    /// </summary>
    public partial class ManagementPortal : Window
    {
        Archive Root = new Archive();
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
            CollectionViewSource gameViewSource = ((CollectionViewSource)(FindResource("gameViewSource")));
            CollectionViewSource myGameViewSource = ((CollectionViewSource)(FindResource("MyGameViewSource")));

            switch (Application.Current.Properties["AccountType"].ToString())
            {
                case "Customer":
                    break;
                case "Submitter":
                    RemoveTabByHeader("All Games");
                    break;
                case "SysAdmin":
                    RemoveTabByHeader("My Games");
                    break;
                default:
                    break;
            }
            _archive.Games.Load();

            gameViewSource.Source = _archive.Games.Local;
            myGameViewSource.Source = _archive.Games.Local.Where(g => g.Submitter.UserName == Application.Current.Properties["Username"].ToString()).ToList();

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
            dg_MyGames.Items.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _archive.Dispose();
        }

        public void RemoveTabByHeader(string name)
        {
            TabItem ti = tc_Portal.Items.OfType<TabItem>().Where(t => t.Header.ToString() == name).FirstOrDefault();
            if (ti != null)
            {
                tc_Portal.Items.Remove(ti);
            }
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            switch (Application.Current.Properties["AccountType"].ToString())
            {
                case "Submitter":
                    if (dg_MyGames.SelectedIndex >= 0 && dg_MyGames.SelectedIndex < dg_MyGames.Items.Count)
                    {
                        Database db = new Database();
                        db.RemoveGameByName(((Game)dg_MyGames.SelectedItem).Title);
                        dg_MyGames.Items.Refresh();
                    }
                    break;
                case "SysAdmin":
                    if (dg_Games.SelectedIndex >= 0 && dg_Games.SelectedIndex < dg_Games.Items.Count)
                    {
                        Database db = new Database();
                        db.RemoveGameByName(((Game)dg_Games.SelectedItem).Title);
                        dg_Games.Items.Refresh();
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
