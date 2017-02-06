using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelephoneDirectoryApplication.Models
{
    public class DirectoryModel
    {
        [Display(Name = "Directory Name")]
        [Required(ErrorMessage = "Directory Name is required ")]
        public string Name { get; set; }
        public int Id { get; set; }
    }
}