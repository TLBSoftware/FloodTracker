using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using FloodTracker.Model;

namespace FloodTracker.Utils
{
    class DataParser
    {

        /// <summary>
        /// Parses standard Discharge tab seperated text file into an array of GaugeSites
        /// </summary>
        /// <param name="textFile">file that contains usgs discharge data</param>
        /// <returns>Gaugesite[] made with textFile</returns>
        public static GageSite[] ParseDischargeToModel(string textFile)
        {

            ArrayList list = new ArrayList();

            foreach (var line in textFile.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
            {
                //If Line starts with USGS and contains atleast 4 forms of data, add to list
                if (line.StartsWith("USGS"))
                {
                    if (line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries).Length > 3)
                        list.Add(line);
                }
            }

            //convert list to string array
            string[] linesOfData = list.ToArray(typeof(string)) as string[];
            GageSite[] returnData = new GageSite[linesOfData.Length];
            for (int i = 0; i < returnData.Length; i++)
            {
                //split line of data by tabs
                string[] data = linesOfData[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

                //assign those values to new GaugeSite object
                returnData[i] = new GageSite()
                {
                    AgencyCd = data[0],
                    SiteNo = data[1],
                    Date = stringToDateTime(data[2])
                };
                double tempDouble = 0.0;
                if (double.TryParse(data[3], out tempDouble))
                {
                    returnData[i].Discharge = tempDouble;
                }

            }
            return returnData;
        }

        /// <summary>
        /// Creates a date time object from a string formatted yyyy-MM-dd
        /// </summary>
        /// <param name="stringDate">string of date in yyyy-MM-dd format</param>
        /// <returns>returns date time object with yyyy-MM-dd assigned</returns>
        public static DateTime stringToDateTime(string stringDate)
        {
            string[] entries = stringDate.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int year, month, day;
            int.TryParse(entries[0], out year);
            int.TryParse(entries[1], out month);
            int.TryParse(entries[2], out day);
            return new DateTime(year, month, day);
        }
    }
}
