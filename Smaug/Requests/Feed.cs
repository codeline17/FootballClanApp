using System;
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

        public static XDocument GetExtendedFixtures(string country)
        {
            return GetXmlFromUrl($"http://www.tipgin.net/datav2/accounts/bsp/soccer/extended_fixtures/{country}.xml");
        }

        private static XDocument GetXmlFromUrl(string url)
        {
            var xml = new XDocument();
            try
            {
                var path = Helper.DownloadAndUnGZip(url);
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
                //
            }
            
            return xml;
        }
    }
}
