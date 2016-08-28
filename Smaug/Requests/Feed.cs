using System;
using System.Diagnostics;
using System.Xml.Linq;
using Smaug.Utils;

namespace Smaug.Requests
{
    public static class Feed
    {
        public static XDocument GetResults()
        {
            //return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/results/{country}.xml","results");
           /* return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/livescore/d-1.xml","results");
            return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/livescore/d-2.xml","results");
            return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/livescore/d-3.xml","results");
            return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/livescore/d-4.xml","results");
            return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/livescore/d-5.xml","results");
            return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/livescore/d-6.xml","results");
            return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/livescore/d-7.xml","results");*/
            return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/livescore/livescore.xml","results");
        }

        public static XDocument GetExtendedFixtures(string country)
        {
            //return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/extended_fixtures/{country}.xml");

            return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/fixtures/{country}.xml");
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
                Console.WriteLine($"Could not get XML from URL {url}");
            }
            
            return xml;
        }
    }
}
