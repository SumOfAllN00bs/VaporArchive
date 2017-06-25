using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace VaporArchive
{
    public class CustomerAccount : Account
    {
        public virtual List<Game> GamesBought { get; set; }
    }
}
