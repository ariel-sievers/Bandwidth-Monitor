using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Timers;

namespace Bandwidth_Monitor
{
    class Program
    {
        //timer which resets after every 5 seconds
        private static void startTimer()
        {
            Timer t = new Timer();
            t.Elapsed += new ElapsedEventHandler(updateUsage);
            t.Interval = 5000;
            t.Enabled = true;
        }

        private static void updateUsage(object source, ElapsedEventArgs e)
        {
            Console.SetCursorPosition(0, 0);
            Monitor.ShowUsage();
        }
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            startTimer();
            Monitor.ShowUsage();
        }
    }
}
