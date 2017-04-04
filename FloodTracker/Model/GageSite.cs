using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodTracker.Model
{
    class GageSite
    {
        public string _agency_cd { get; set; }
        public string _site_no { get; set; }
        public DateTime _datetime { get; set; }
        public double _discharge { get; set; }
    }
}
