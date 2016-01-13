using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowNg.Helpers
{
    public static class APIHelper
    {
        private static HttpWebRequest BuildRequest(string path)
        {
            string user = null, password = null;

            //SNInstance = (string.IsNullOrEmpty(instance)) ? "default" : instance;

            //Configuration.GetApiCredentials(SNInstance, out SNUrl, out SNUser, out SNPassword);

            // Use this code for testing this helper from playground. Comment out initialization above.
            //string SNUrl = "https://ven01417.service-now.com";
            //string SNUser = "admin";
            //string SNPassword = "admin";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
            request.Credentials = new NetworkCredential(user, password);
            request.PreAuthenticate = true;

            return request;
        }

        private static string ReadHttpResponse(HttpWebResponse response)
        {
            string resultJson;
            using (var s = new StreamReader(response.GetResponseStream()))
            {
                resultJson = s.ReadToEnd();
            }
            return resultJson;
        }

    }
}
