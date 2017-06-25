using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VaporArchive
{
    abstract class Portal
    {
        public TabControl Tab { get; set; }
        public Portal(TabControl tbControl)
        {
            Tab = tbControl;
        }
        public abstract void Setup();
        //public abstract void Destroy();
    }
}
