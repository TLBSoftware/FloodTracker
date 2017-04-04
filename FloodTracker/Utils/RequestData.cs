using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace FloodTracker.Utils
{
    class RequestData
    {
        public static string RetrieveData(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            // Get the stream containing all content returned by the requested server.
            Stream dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);

            // Read the content fully up to the end.
            string getRequest = reader.ReadToEnd();


            return getRequest;
        }
    }
}
