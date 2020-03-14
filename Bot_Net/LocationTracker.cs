using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bot_Net
{
    public class LocationTracker
    {
        public static string GetCountryByIP(string ipAddress)
        {
            string strReturnVal;
            string ipResponse = IPRequestHelper("http://ip-api.com/xml/" + ipAddress);

            //return ipResponse;
            XmlDocument ipInfoXML = new XmlDocument();
            ipInfoXML.LoadXml(ipResponse);
            XmlNodeList responseXML = ipInfoXML.GetElementsByTagName("query");

            NameValueCollection dataXML = new NameValueCollection();

            dataXML.Add(responseXML.Item(0).ChildNodes[2].InnerText, responseXML.Item(0).ChildNodes[2].Value);

            strReturnVal = responseXML.Item(0).ChildNodes[1].InnerText.ToString(); // Country

            strReturnVal += "(" +

    responseXML.Item(0).ChildNodes[2].InnerText.ToString() + ")";  // Country Code 
            strReturnVal += "(" +

    responseXML.Item(0).ChildNodes[5].InnerText.ToString() + ")";
            strReturnVal += "(" +

    responseXML.Item(0).ChildNodes[7].InnerText.ToString() + "," + responseXML.Item(0).ChildNodes[8].InnerText.ToString() + ")";
            strReturnVal += "(" +

    responseXML.Item(0).ChildNodes[10].InnerText.ToString() + ")";
            Console.WriteLine("You IP location is traced out to be from : {0}", strReturnVal);
            return strReturnVal;
        }

        private static string IPRequestHelper(string url)
        {

            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();

            StreamReader responseStream = new StreamReader(objResponse.GetResponseStream());
            string responseRead = responseStream.ReadToEnd();

            responseStream.Close();
            responseStream.Dispose();
            
            return responseRead;
        }
    }
}
