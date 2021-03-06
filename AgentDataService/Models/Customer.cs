﻿namespace DataService.Models
{
    public class Customer
    {
        public int _id { get; set; }
        public int agent_id { get; set; }
        public string guid { get; set; }
        public bool isActive { get; set; }
        public string balance { get; set; }
        public int age { get; set; }
        public string eyeColor { get; set; }
        public Name name { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string registered { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string[] tags { get; set; }
    }

}
