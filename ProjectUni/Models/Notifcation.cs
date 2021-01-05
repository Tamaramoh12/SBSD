using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUni.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public string body { get; set; }
        public int idadv { get; set; }
        public string userid { get; set; }

    }
}