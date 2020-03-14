using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Net
{
    public class IPTracker
    {
        public static string IPChecker()
        {
            string IP = null;
            Console.WriteLine("*************Welcome To IP Tracker********************");
            Console.WriteLine("Select your option:");
            Console.WriteLine("1: Display Public IP");
            Console.WriteLine("2: Display Private IP");
            Console.WriteLine("Enter your Choice:");
            string input = Console.ReadLine();
            while (input != null)
            {
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Your Public IP is : {0}", FindPublicIP());
                        IP = FindPublicIP();
                        break;
                    case "2":
                        Console.WriteLine("Your Private IP is : {0}", FindPrivateIP());
                        IP =  FindPrivateIP();
                        break;
                    default:
                        Console.WriteLine("Invalid Entry");
                        break;
                }
                input = null;
                
            }

            return IP;
        }

        private static string FindPublicIP()
        {
            String direction = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                direction = stream.ReadToEnd();
            }

            //Search for the ip in the html
            int first = direction.IndexOf("Address: ") + 9;
            int last = direction.LastIndexOf("</body>");
            direction = direction.Substring(first, last - first);

            return direction;
        }

        private static string FindPrivateIP()
        {
            var IP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            return IP.ToString();
        }
    }
}
