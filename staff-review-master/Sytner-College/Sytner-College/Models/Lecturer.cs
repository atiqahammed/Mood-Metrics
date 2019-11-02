using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SytnerCollege.Models
{
    public class Lecturer
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        
        [Display(Name = "Email Address")]
        [StringLength(254)]
        public string EmailAddress { get; set;}

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstMidName; }
        }
        //A Lecturer can teach any number of courses
        public ICollection<CourseAssignment> CourseAssignments { get; set; }

        //This will depict the relation that a lecturer can at most have just one office. 
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
