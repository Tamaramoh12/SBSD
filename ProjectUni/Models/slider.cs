using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUni.Models
{
    public class slider:BaseEntity
    {
        public string Text { get; set; }
        public string Links { get; set; }
        public byte[] photo { get; set; }
    }
}