using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUni.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreationTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string CreateionUser { get; set; }
    }
}