using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    public class Subject
    {
        [Key]

        [Required(ErrorMessage = "Subject Code is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Subject Code must be a number.")]
        public int SubjectCode { get; set; }

        [Required(ErrorMessage = "Subject Name is required.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Subject Name can only contain letters and numbers.")]
        [StringLength(100, ErrorMessage = "Subject Name cannot be longer than 100 characters.")]
        public string SubjectName { get; set; }

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
