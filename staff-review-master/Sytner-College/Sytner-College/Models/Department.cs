using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SytnerCollege.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public int? LecturerID { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } //This attribute specifies that this column will be included in the Where clause of Update and Delete commands sent to the database

        public Lecturer Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}