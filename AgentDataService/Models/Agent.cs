using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{
    public class Agent
    {
        public int _id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public int tier { get; set; }
        public Phone phone { get; set; }
    }

}
