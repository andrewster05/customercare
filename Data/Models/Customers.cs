using CustomerCare.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CustomerCare.Data.Models
{
    public partial class Customers
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Country")]
        public Country? Country { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "System Role")]
        public SystemRole? SystemRole { get; set; }
    }

    public class CustomersSearchResult
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Country")]
        public Country? Country { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "System Role")]
        public SystemRole? SystemRole { get; set; }

        [Display(Name = "Row Number")]
        public long RowNumber { get; set; }

        [Display(Name = "Total Count")]
        public int TotalCount { get; set; }
    }
}
