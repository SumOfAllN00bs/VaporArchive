using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaporArchive
{
    class SubmitterArchive : Archive
    {
        private SubmitterAccount ArchiveSubmitter;
        public override List<Game> Games
        {
            get
            {
                Database db = new Database();
                return db.GetGamesBySubmitter(ArchiveSubmitter.UserName);
            }
        }
        public SubmitterArchive(SubmitterAccount _archiveSubmitter) : base()
        {
            ArchiveSubmitter = _archiveSubmitter;
        }

        public SubmitterArchive(SubmitterAccount _archiveSubmitter, string root) : base(root) //in this case submitter directory should be used as root
        {
            ArchiveSubmitter = _archiveSubmitter;
        }
    }
}
