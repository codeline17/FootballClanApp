using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Smaug.Utils
{
    public static class Elements
    {
        public static string[] ExtendedFixturesCountries = {"albania", "algeria", "andorra", "angola", "argentina", "armenia", "aruba", "australia", "austria", "azerbaijan", "bahrain", "bangladesh", "barbados", "belarus", "belgium", "belize", "bermuda", "bhutan", "bolivia", "bosnia", "botswana", "brazil", "brunei", "bulgaria", "cambodia", "cameroon", "canada", "chile", "china", "chinesetaipei", "colombia", "costarica", "croatia", "cyprus", "czech", "denmark", "ecuador", "egypt", "elsalvador", "england", "estonia", "europe", "faroeislands", "fiji", "finland", "france", "friendly", "gabon", "georgia", "germany", "ghana", "greece", "grenada", "guadeloupe", "guatemala", "haiti", "holland", "honduras", "hongkong", "hungary", "iceland", "india", "indonesia", "international", "iran", "iraq", "ireland", "israel", "italy", "ivorycoast", "jamaica", "japan", "jordan", "kazakhstan", "korea", "kuwait", "latvia", "lebanon", "libya", "lithuania", "luxembourg", "macedonia", "malaysia", "malta", "mexico", "moldova", "montenegro", "morocco", "namibia", "nepal", "newzealand", "nicaragua", "nigeria", "northernireland", "norway", "oman", "pakistan", "panama", "paraguay", "peru", "poland", "portugal", "qatar", "romania", "russia", "sanmarino", "saudiarabia", "scotland", "senegal", "serbia", "singapore", "slovakia", "slovenia", "southafrica", "spain", "sudan", "surinam", "sweden", "switzerland", "syria", "thailand", "trinidadandtobago", "tunisia", "turkey", "uae", "ukraine", "uruguay", "usa", "uzbekistan", "venezuela", "vietnam", "wales", "worldcup", "yemen"};
        public static string CurrentEFCountry;
    }
    public static class Helper
    {
        public static T FromXml<T>(string xml)
        {
            var returnedXmlClass = default(T);

            try
            {
                using (TextReader reader = new StringReader(xml))
                {
                    try
                    {
                        returnedXmlClass =
                            (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                    }
                    catch (InvalidOperationException)
                    {
                        // String passed is not XML, simply return defaultXmlClass
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO : Handle
            }

            return returnedXmlClass;
        }

        public static string DownloadAndUnGZip(string url)
        {
            var r = "";

            var outputPath = DownloadFromUrl(url);
            r = outputPath.Length > 0 ? UnGZipFromPath(outputPath) : r;             

            return r;
        }

        private static string DownloadFromUrl(string url)
        {
            var r = "";
            try
            {
                using (WebClient myWebClient = new WebClient())
                {
                    string filename = url.Split('/').Last();
                    var fName = "XMLs\\ExtendedFeeds\\" + filename.Split('.')[0];
                    myWebClient.DownloadFile(url, fName);
                    r = fName;
                }
            }
            catch (Exception ex)
            {
                
            }
            return r;
        }

        private static string UnGZipFromPath(string path)
        {
            var r = "";

            try
            {
                using (FileStream fInStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (GZipStream zipStream = new GZipStream(fInStream, CompressionMode.Decompress))
                    {
                        using (FileStream fOutStream =
                          new FileStream($"{path}.xml", FileMode.Create, FileAccess.Write))
                        {
                            byte[] tempBytes = new byte[4096];
                            int i;
                            while ((i = zipStream.Read(tempBytes, 0, tempBytes.Length)) != 0)
                            {
                                fOutStream.Write(tempBytes, 0, i);
                            }
                        }
                    }
                }
                r = $"{path}.xml";
            }
            catch (Exception)
            {
                
            }

            return r;
        }
    }
}
