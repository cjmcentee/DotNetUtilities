using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsExtensions
{
    public static class EventDelegates
    {
        public delegate void ValueChanged(object sender, EventArgs e);
    }
}
