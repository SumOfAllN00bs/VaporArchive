using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VaporArchive
{
    class CustomerPortal : Portal
    {
        public CustomerPortal(TabControl tbControl) : base(tbControl)
        {
        }

        public override void Setup()
        {
            Tab.Items.Clear();
            TabItem ti = new TabItem();
            ti.Header = "Archive Of Games";
            Tab.Items.Add(ti);
        }
    }
}
