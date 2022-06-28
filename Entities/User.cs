using System.ComponentModel.DataAnnotations;

namespace ToDoList.Entities
{
    public class User
    {
        public int Id { get; set; }


        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [MinLength(6, ErrorMessage = "At least 6 digits")]
        [MaxLength(32, ErrorMessage = "Maximum 32 digits")]
        public string? Password { get; set; }


        public string? PasswordConfirm { get; set; }
    }
}
