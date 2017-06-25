using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace VaporArchive
{
    class Account
    {
        [Key]
        public int AccountID { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(1000)]
        public string PasswordHash { get; set; }

        [Required]
        public DateTime AccountCreated { get; set; }
    }
}
