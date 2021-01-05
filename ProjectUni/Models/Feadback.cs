using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectUni.Models
{
    public class Feadback:BaseEntity
    {
        [Required(ErrorMessage = "الرجاء ادخال الاسم")]
        public String name { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال بريدك الالكتروني")]
        [DataType(DataType.EmailAddress, ErrorMessage = "الرجاء ادخال بريد الكتروني صالح")]
      
        public string email { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال رقم هاتفك")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "ادخل رقم هاتف صحيح")]

        public string phone { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string note { get; set; }

    }
}