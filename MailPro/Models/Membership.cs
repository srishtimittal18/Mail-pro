using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MailPro.Models
{
    public class Membership
    {
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }
        public string FacultyEmail { get; set; }
        public int FacultyPhoneNo { get; set; }
        public string Department { get; set; }
        public string Password { get; set; }
        public virtual ICollection<CategoryTable> CategoryTable { get; set; }
    }
}