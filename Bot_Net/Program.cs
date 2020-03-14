using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var IP = IPTracker.IPChecker();
            if (IP.ToString().Contains("192.168"))
            {

            }
            else
            {
                var location = LocationTracker.GetCountryByIP(IP);

            }
            PingSweep.Pinger();
            Console.ReadLine();
        }

       
    }
}
