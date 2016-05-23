using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using Smaug.Models;

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
                xml = XDocument.Load(url);
            }
            catch (Exception ex)
            {
                //
            }
            
            return xml;
        }
    }
}
