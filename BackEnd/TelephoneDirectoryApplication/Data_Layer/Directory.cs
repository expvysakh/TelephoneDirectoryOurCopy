using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelephoneDirectoryApplication.Data_Layer
{
    public class Directory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PhoneNumber> DirectoryRecord { get; set; }
    }
}