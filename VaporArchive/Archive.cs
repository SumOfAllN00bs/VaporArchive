using System;
using System.Collections.Generic;
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
                    var archiveDirectory = cwd + @"\" + root;
                    if (cwd.Split('\\').LastOrDefault() == "Archive")
                    {
                        DirectoryInfo di = Directory.CreateDirectory(archiveDirectory);
                        RootDirectory = archiveDirectory;
                    }
                    else
                    {
                        MessageBox.Show("Error");
                        return;
                    }
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
