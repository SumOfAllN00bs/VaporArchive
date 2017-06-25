using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VaporArchive
{
    class SysAdminPortal : Portal
    {
        public SysAdminPortal(TabControl tbControl) : base(tbControl)
        {
        }
        public override void Setup()
        {
            Tab.Items.Clear();

            TabItem GamesTI = new TabItem();
            TabItem ArchiveTI = new TabItem();
            TabItem CustomerAccountsTI = new TabItem();
            TabItem SubmitterAccountsTI = new TabItem();

            GamesTI.Header = "Games List"; //Lists all games
            ArchiveTI.Header = "Archive Of Games"; //Controls Archive structure and other options
            CustomerAccountsTI.Header = "Customers Accounts"; //Controls Customer Accounts
            SubmitterAccountsTI.Header = "Submitters Accounts"; //Controls Submitter Accounts

            Tab.Items.Add(GamesTI);
            Tab.Items.Add(ArchiveTI);
            Tab.Items.Add(CustomerAccountsTI);
            Tab.Items.Add(SubmitterAccountsTI);
        }
    }
}
