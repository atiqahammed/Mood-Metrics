using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SytnerCollege.Models
{
    public class CourseAssignment
    {
        public int LecturerID { get; set; }
        public int CourseID { get; set; }
        public Lecturer Lecturer { get; set; }
        public Course Course { get; set; }
    }
}
