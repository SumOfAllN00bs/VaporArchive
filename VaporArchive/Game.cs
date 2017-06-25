using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace VaporArchive
{
    class Game
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
        public virtual SubmitterAccount Submitter { get; set; }
        public virtual List<CustomerAccount> Customers { get; set; }
    }
}
