using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SytnerCollege.Models
{
    public class OfficeAssignment
    {
        
        [Key]
        public int LecturerID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        public Lecturer Lecturer { get; set; } 
         
    }
}