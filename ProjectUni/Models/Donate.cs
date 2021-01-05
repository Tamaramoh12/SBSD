using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectUni.Models
{
    public class Donate:BaseEntity
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string FromEmail { get; set; }
        [Required]
        public List<Images>Image { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال أسمك")]
        public string name { get; set; }
        [Required(ErrorMessage = "أدخل رقم الهاتف")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "أدخل رقم هاتف صحيح")]
        public string Phone { get; set; }
        //location
        [Required(ErrorMessage = "ادخل مكان سكنك ")]
        public string Longitude { get; set; }
        
    }
}