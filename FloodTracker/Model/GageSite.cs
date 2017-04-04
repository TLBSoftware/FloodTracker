using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodTracker.Model
{
    class GageSite
    {
        private string _agencyCd;
        private string _siteNo;
        private DateTime _dateTime;
        private double _discharge;

        public string AgencyCd
        {
            get { return _agencyCd; }
            set { _agencyCd = value; }
        }
        public string SiteNo
        {
            get { return _siteNo; }
            set { _siteNo = value; }
        }
        public DateTime Date
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }
        public double Discharge
        {
            get { return _discharge; }
            set { _discharge = value; }
        }
    }
}
