using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public int client_id { get; set; }
        public string client_name { get; set; }
        public string client_sname { get; set; }
        public int cours_id { get; set; }
        public string cours_name { get; set; }
        public string date { get; set; }
        public string time { get; set; }
    }
}