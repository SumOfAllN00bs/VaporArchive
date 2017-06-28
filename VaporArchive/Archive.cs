using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VaporArchive
{
    public class Archive
    {
        string _RootDirectory = "";
        public virtual List<Game> Games
        {
            get
            {
                Database db = new Database();
                return db.GetGames();
            }
        }
        public Archive() : this("")
        {
        }
        public Archive(string root)
        {
            try
            {
                if (root == "")
                {
                    var cwd = Directory.GetCurrentDirectory();
                    var archiveDirectory = cwd + @"\" + "Archive";
                    if (Directory.GetDirectories(cwd).Contains(archiveDirectory))
                    {
                        RootDirectory = archiveDirectory;
                    }
                    else
                    {
                        DirectoryInfo di = Directory.CreateDirectory(archiveDirectory);
                        RootDirectory = archiveDirectory;
                    }
                }
                else
                {
                    var cwd = Directory.GetCurrentDirectory();
                    var archiveDirectory = cwd + @"\" + "Archive" + @"\" + root; //current working directory or cwd is going to be the folder that contains Archive and inside Archive 
                                                                                 //are all the folders that correspond to the submitters name and in those folders are the actual games per submitter
                    DirectoryInfo di = Directory.CreateDirectory(archiveDirectory);
                    RootDirectory = archiveDirectory;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public string RootDirectory
        {
            get
            {
                return _RootDirectory;
            }
            set
            {
                _RootDirectory = value;
            }
        }
    }
}
