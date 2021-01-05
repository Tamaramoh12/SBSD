using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectUni.Models
{
    public class Adv:BaseEntity
        // seller form 
    {

        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "ادخل رقم هاتف صحيح")]

        public string phone { get; set; }

        [Required]

        public string title { get; set; }

        
        public string link { get; set; }
        

        public bool ForSwap { get; set; }


        public string userid { get; set; }

        [Required]
        public string Address { get; set; }


        [Required]
        public string body { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public int price { get; set; }

        public bool forswapping { get; set; }

        public bool IsActive { get; set; }
        public bool? ispro { get; set; }

        [Required]

        public List<Images> images { get; set; }
        public List<comment> comments { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

    }
}