using System;
using System.Diagnostics;
using System.Xml.Linq;
using Smaug.Utils;

namespace Smaug.Requests
{
    public static class Feed
    {
        public static XDocument GetResults(string country)
        {
            return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/results/{country}.xml","results");
        }

        public static XDocument GetExtendedFixtures(string country)
        {
            return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/extended_fixtures/{country}.xml");
        }

        private static XDocument GetXmlFromUrl(string url,string type = "extended")
        {
            var xml = new XDocument();
            try
            {
                var path = Helper.DownloadAndUnGZip(url, type);
                if (path != "")
                {
                    xml = XDocument.Load(path);
                }
                else
                    Console.WriteLine(url);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                Debug.WriteLine($"Could not get XML from URL {url}");
            }
            
            return xml;
        }
    }
}
