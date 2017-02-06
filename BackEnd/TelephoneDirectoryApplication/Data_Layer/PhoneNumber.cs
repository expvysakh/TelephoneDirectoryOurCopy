using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelephoneDirectoryApplication.Data_Layer
{
    public class PhoneNumber
    {
        public int RecordId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
        public virtual Directory DirectoryList { get; set; }
        public int DirectoryId { get; set; }
    }
}