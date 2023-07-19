using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Xml.Linq;

namespace LibraryMgmt.WebApp.MVC.DTOs
{
    public class StaffDTO_client
    {
        [Required]
        [StringLength(50,ErrorMessage ="Name is too long")]
        [MinLength(3, ErrorMessage="Please enter a valid name")]
        [DisplayName("Staff Name")]
        public string StaffName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name is too long")]
        [MinLength(3, ErrorMessage = "Please enter a valid name")]
        [DisplayName("Staff Role")]
        public string StaffRole { get; set; }
    }
}
