using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace Bandwidth_Monitor
{
    class Report {

        private MailboxAddress rcpt = new MailboxAddress(Properties.Settings.Default.EmailAddress);
        private string username;
        private string password;

        private SmtpClient client = new SmtpClient();
        private string serverName;
        private static int PORT;

        private bool send = Properties.Settings.Default.SendReport;

        DataTable dt = new DataTable();
        //string dbLocation = "F:/Users/Ariel Sievers/Desktop/Side Projects/Bandwidth Monitor/Bandwidth Monitor/MonitorDB.mdf";
        SqlConnection conn = new SqlConnection("F:/Users/Ariel Sievers/Desktop/Side Projects/Bandwidth Monitor/Bandwidth Monitor/MonitorDB.mdf");
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        
        // return email address according to settings file
        MailboxAddress GetAddress()
        {
            return rcpt;
        }

        //report functions
        //on/off sending of report
        //obtaining data from database and compiling into report

        // return boolean according to settings file
        // if true, then send report weekly
        bool SendReport()
        {
            return send;
        }

        int GetDownloadedBytes()
        {
            return 0;
        }


    }
}
