using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUni.Models
{
    // header + footer
    public class menu:BaseEntity
    {
        public string text { get; set; }
        public string link { get; set; }
        public string Type { get; set; }
        public int auth { get; set; }


    }
}