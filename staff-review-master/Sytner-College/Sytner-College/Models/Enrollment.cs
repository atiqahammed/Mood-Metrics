using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SytnerCollege.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; } 
        public int CourseID { get; set; } //An enrollment record is for a single course
        public int StudentID { get; set; } //A Student can enroll on many courses.

        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        //Navigation properties. 
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
    public enum Grade
    {
        A, B, C, D, U
    }
}