using System;
using System.Collections.Generic;
using System.Text;

namespace RetailPlatform.Core.Config
{
    public class EmailConfig
    {
        //public string IMAPServer { get; set; }
        //public int IMAPPort { get; set; }
        //public string IMAPUsername { get; set; }
        //public string IMAPPassword { get; set; }
        //public int ExecuteEachNumberOfSeconds { get; set; }
        //public int DefaultPageSize { get; set; }
        //public int MaxPageSize { get; set; }
        public string SendGridAPIKey { get; set; }
        public string SendGridSender { get; set; }
        public string SendFrom { get; set; }
    }
}
