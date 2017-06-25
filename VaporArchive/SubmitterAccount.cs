using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace VaporArchive
{
    class SubmitterAccount : Account
    {
        public virtual List<Game> GamesSubmitted { get; set; }

    }
}
