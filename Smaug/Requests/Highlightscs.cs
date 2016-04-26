using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Smaug.Utils;

namespace Smaug.Requests
{
    public static class Feed
    {
        public static XDocument GetHighlights(string days)
        {
            //http://www.tipgin.net/datav2/accounts/bsp/soccer/highlights/d-1.xml
            days = days == "today" ? days : "d" + days;

            return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/highlights/{days}.xml");
        }

        public static XDocument GetExtendedFixtures()
        {
            return GetXmlFromUrl("http://feed.me/england-demo.xml");
        }

        private static XDocument GetXmlFromUrl(string url)
        {
            var xml = new XDocument();
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("url");
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                request.Accept = "application/xml";

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var statusCode = (int)response.StatusCode;
                    if (response == null) return xml;
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        xml = XDocument.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
            
            return xml;
        }
    }
}
