using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.ModelsDB;

namespace WebApplication2.Models
{
    public class MyModels
    {
    }

    public class AddL
    {
        public string name { get; set; }
        public string dis { get; set; }
        public string price { get; set; }
        public string aria { get; set; }
        public string type { get; set; }
        public string street { get; set; }
        public string district { get; set; }
        public string num_house { get; set; }
        public string num_flat { get; set; }
        public string count_rooms { get; set; }
        public string img_folder { get; set; }
    }

    public class LAD
    {
        public List<district> Districts { get; set; }
        public List<lots_type> LotsTypes { get; set; }
    }
}