using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectUni.Models
{
    public class Images:BaseEntity
    {
        public byte[] image { get; set; }
        public int? IdAdv { get; set; }
        [ForeignKey(nameof(IdAdv))]
        public Adv Adv { get; set; }
        public int? DonateId { get; set; }

        [ForeignKey(nameof(DonateId))]

        public Donate donate { get; set; }

        public int? idcomment { get; set; }

        [ForeignKey(nameof(idcomment))]

        public comment comment { get; set; }
    }
}