using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Bandwidth_Monitor
{
    static class Monitor
    {
        private static NetworkInterface[] interfaces;

        private static long GetBytesSent(NetworkInterface netInt)
        {
            return netInt.GetIPv4Statistics().BytesSent;
        }

        private static long GetBytesReceived(NetworkInterface netInt)
        {
            return netInt.GetIPv4Statistics().BytesReceived;
        }


        private static void GetNetworkInterfaces()
        {
            //return null if not connected to any network
            if (!NetworkInterface.GetIsNetworkAvailable())
                return;

            interfaces = NetworkInterface.GetAllNetworkInterfaces();
        }

        private static string Banner(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                sb.Append('-');
            }

            return sb.ToString();
        }

        private static long BytesToMB(long b)
        {
            return b / 1000000;
        }

        public static void ShowUsage()
        {
            GetNetworkInterfaces();

            foreach (NetworkInterface netInt in interfaces)
            {
                Console.WriteLine("     " + Banner(netInt.Name));
                Console.WriteLine("     " + netInt.Name);
                Console.WriteLine("     " + Banner(netInt.Name));
                Console.WriteLine("     Bytes Uploaded: {0} {1}", BytesToMB(GetBytesSent(netInt)), "MB");
                Console.WriteLine("     Bytes Downloaded: {0} {1}", BytesToMB(GetBytesReceived(netInt)), "MB");
                Console.WriteLine();
            }

            Console.ReadLine();
        }



    }
}
