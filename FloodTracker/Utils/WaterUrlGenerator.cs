using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodTracker.Utils
{
    class WaterUrlGenerator
    {
        private string _cb_00060;
        private string _format;
        private string _site_no;
        private string _referred_module;
        private string _period;
        private DateTime _endDate;
        private DateTime _beginDate;

        /* https://
         * waterdata.usgs.gov/nwis/dv?
         * cb_00060=on
         * &format=rdb
         * &site_no=06919020
         * &referred_module=sw
         * &period=
         * &begin_date=2016-01-30
         * &end_date=2017-01-29
        */

        public WaterUrlGenerator(string siteNum)
        {
            _site_no = siteNum;
            _endDate = DateTime.Now;
            _beginDate = _endDate.Subtract(new TimeSpan(365, 0, 0, 0));
            setOtherValues();
        }

        public WaterUrlGenerator(string siteNum, DateTime earlierDate, DateTime laterDate)
            : this(siteNum)
        {
            if (laterDate > earlierDate)
            {
                var temp = laterDate;
                laterDate = earlierDate;
                earlierDate = temp;
            }

            _endDate = laterDate; _beginDate = earlierDate;
            setOtherValues();
        }

        private void setOtherValues()
        {
            _cb_00060 = "on";
            _format = "rdb";
            _referred_module = "sw";
        }

        public string GetUrl()
        {
            //Begin date needs to be the earlier value
            return "https://waterdata.usgs.gov/nwis/dv?"
            + "cb_00060=" + _cb_00060
            + "&format=" + _format
            + "&site_no=" + _site_no
            + "&referred_module=" + _referred_module
            + "&period=" + _period
            + "&begin_date=" + yearMonthDay(_beginDate)
            + "&end_date=" + yearMonthDay(_endDate);


        }

        public string yearMonthDay(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
