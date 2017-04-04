using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodTracker.Model
{
    class GageSiteURL : ObservableObject
    {
        private string _cb_00060;
        private string _format;
        private string _site_no;
        private string _referred_module;
        private string _period;
        private DateTime _endDate;
        private DateTime _beginDate;
        private string _url;

        public string URL
        {
            get { return _url; }
            set { OnPropertyChanged<string>(ref _url, value); }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { OnPropertyChanged<DateTime>(ref _endDate, value); }
        }
        public DateTime BeginDate
        {
            get { return _beginDate; }
            set { OnPropertyChanged<DateTime>(ref _beginDate, value); }
        }

        public GageSiteURL(string siteNum, DateTime earlierDate, DateTime laterDate)
        {
            
        }
    }
}
