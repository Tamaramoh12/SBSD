using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUni.Models
{
    // الفئات للأدمن
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string img { get; set; }
        public string link { get; set; }
        public int price { get; set; }
        public List<Adv> advs { get; set; }
    }
}