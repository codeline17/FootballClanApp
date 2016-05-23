using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using Smaug.Models;
using Smaug.Utils;
using System.Net;
using System.IO.Compression;

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
                xml = XDocument.Load(path);
            }
            catch (Exception ex)
            {
                //
            }
            
            return xml;
        }
    }
}
