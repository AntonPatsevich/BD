using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.ModelsDB;

namespace WebApplication2.Models
{
    public class lotsviewModels
    {
        public List<lot> lots;
        public SelectList Names;
        public string lotName { get; set; }
        public string SearchString { get; set; }

    }
}