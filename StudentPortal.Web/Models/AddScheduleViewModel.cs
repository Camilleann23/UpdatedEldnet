using System;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    public class AddScheduleViewModel
    {

        [Required(ErrorMessage = "EDP Code is required")]
        public int EDPCode { get; set; }

        [Required(ErrorMessage = "Subject Code is required")]
        public string SubjectCode { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "can only contain letters.")]

        public string Description { get; set; }

        [Required(ErrorMessage = "Section is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Course Code can only contain letters.")]
        public string Section { get; set; }

        [Required(ErrorMessage = "Start Time is required")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "End Time is required")]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        [Required(ErrorMessage = "Days are required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Days can only contain letters.")]
        public string Days { get; set; }

        [Required(ErrorMessage = "Room number is required")]
        [RegularExpression(@"^\d+$", ErrorMessage = " must be a number.")]
        public string Room { get; set; }

        [Required(ErrorMessage = "Curriculum Year is required")]
        [RegularExpression(@"\d{4}-\d{4}", ErrorMessage = "Curriculum Year must be in the format YYYY-YYYY")]
        public string CurriculumYear { get; set; }
    }
}
