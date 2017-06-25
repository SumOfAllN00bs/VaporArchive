﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VaporArchive
{
    class SubmitterPortal : Portal
    {
        public SubmitterPortal(TabControl tbControl) : base(tbControl)
        {
        }

        public override void Setup()
        {
            Tab.Items.Clear();

            TabItem GamesTI = new TabItem();
            TabItem ArchiveTI = new TabItem();

            GamesTI.Header = "Games List"; //Lists all games of submitter
            ArchiveTI.Header = "Archive Of Games"; //Controls Archive structure and other options for submitter

            Tab.Items.Add(GamesTI);
            Tab.Items.Add(ArchiveTI);
        }
    }
}
