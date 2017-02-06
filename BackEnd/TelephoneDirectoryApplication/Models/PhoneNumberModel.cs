using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelephoneDirectoryApplication.Models
{
    public class PhoneNumberModel
    {
        

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required ")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required ")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is mandatory")]
        [MaxLength(10)]
        [RegularExpression(@"^([0]|\+91)?[789]\d{9}$", ErrorMessage = "Enter phone number in indian format")]
        public string TelephoneNumber { get; set; }

        [Required(ErrorMessage = "Address field is required ")]
        public string Address { get; set; }

        public virtual DirectoryModel DirectoryList { get; set; }
        public int DirectoryId { get; set; }
        public string DirectoryName { get; set; }
        public int RecordId { get; set; }
    }
}