using ProjectUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUni
{
    public class VMnotification
    {
        public int Count { get; set; }
        public List<Notification> notifications { get; set; }
    }
}