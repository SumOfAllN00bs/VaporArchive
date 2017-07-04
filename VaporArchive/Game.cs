using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace VaporArchive
{
    public class Game : INotifyPropertyChanged
    {
        [Key]
        public int GameID { get; set; }
        [Required]
        public string Title { get; set; }
        public string FilePath { get; set; }
        public int SizeKB { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int Price { get; set; }
        public string Genre { get; set; }
        [Required]
        public int SubmitterID { get; set; }
        public virtual SubmitterAccount Submitter { get; set; }
        public virtual List<CustomerAccount> Customers { get; set; }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
