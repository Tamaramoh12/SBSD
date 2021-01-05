using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectUni.Models
{
    public class comment:BaseEntity

    {
        public int idadv { get; set; }
        [ForeignKey(nameof(idadv))]
        public Adv adv { get; set; }
        public String name { get; set; }
        public String phone { get; set; }
        public List<Images> image { get; set; }

    }
}