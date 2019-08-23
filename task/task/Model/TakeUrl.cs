using System;
using System.Collections.Generic;
using System.Text;

namespace url.Model
{

    public class CacheJson
    {
        public string hostname { get; set; }
        public string motherbord { get; set; }
        public string hdd { get; set; }
        public string network { get; set; }
        public string ip_address { get; set; }
        public Display[] displays { get; set; }
    }

    public class Display
    {
        public string id { get; set; }
        public string refresh_rate { get; set; }
        public string manufacturer { get; set; }
        public Application[] applications { get; set; }
    }

    public class Application
    {
        public string name { get; set; }
        public string runtime { get; set; }
        public string url { get; set; }
    }

}
