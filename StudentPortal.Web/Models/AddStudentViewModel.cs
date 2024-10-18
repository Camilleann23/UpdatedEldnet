using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    public class AddStudentViewModel
    {
        [Required(ErrorMessage = "ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid ID.")]
        public int ID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name cannot contain numbers.")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name cannot contain numbers.")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Course is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Course cannot contain numbers.")]

        public string Course { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [RegularExpression(@"^[0-9]{1,2}$", ErrorMessage = "Year must be a number between 1-5.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Status cannot contain numbers.")]

        public string Status { get; set; }
    }
}
