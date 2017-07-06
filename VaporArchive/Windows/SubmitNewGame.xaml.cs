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
using Microsoft.Win32;
using System.IO;

namespace VaporArchive.Windows
{
    /// <summary>
    /// Interaction logic for SubmitNewGame.xaml
    /// </summary>
    public partial class SubmitNewGame : Window
    {
        public static Game newGame;

        public SubmitNewGame()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtb_SubmitterName.Text = Application.Current.Properties["Username"].ToString();
        }

        private void btn_FindGame_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".zip";
            dlg.Filter = "Zip Files (*.zip)|*.zip|Exe Files (* .exe)|*.exe";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                txt_FileName.Text = dlg.FileName;
            }
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(txt_FileName.Text))
                {
                    Database db = new Database();
                    string SubmitterAccountName;
                    if (string.IsNullOrWhiteSpace(Application.Current.Properties["Username"].ToString()))
                    {
                        SubmitterAccountName = null;
                    }
                    else
                    {
                        SubmitterAccountName = Application.Current.Properties["Username"].ToString();
                    }
                    bool result = db.SubmitNewGame(txt_Title.Text, txt_FileName.Text, Convert.ToInt32(new FileInfo(txt_FileName.Text).Length / 1000), DateTime.Now, Convert.ToInt32(txt_Price.Text), txt_Genre.Text, SubmitterAccountName);

                    if (result)
                    {
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
