using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    public class AddSubjectViewModel
    {
        [Required(ErrorMessage = "Subject Code is required.")]
        public string SubjectCode { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Description can only contain letters.")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Units are required.")]
        [Range(1, 10, ErrorMessage = "Units must be between 1 and 10.")]
        public int Units { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Offering can only contain letters and numbers.")]
        [StringLength(50, ErrorMessage = "Offering cannot be longer than 50 characters.")]
        public string Offering { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Category can only contain letters.")]
        [StringLength(50, ErrorMessage = "Category cannot be longer than 50 characters.")]
        public string Category { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Course Code can only contain letters.")]
        [StringLength(50, ErrorMessage = "Course Code cannot be longer than 50 characters.")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Curriculum Year is required.")]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Curriculum Year must be in the format YYYY-YYYY.")]

        public string CurriculumYear { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Requisite can only contain letters and numbers.")]
        [StringLength(50, ErrorMessage = "Requisite cannot be longer than 50 characters.")]
        public string Requisite { get; set; }
    }
}
