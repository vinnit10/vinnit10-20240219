using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class UpdateUserViewModel
    {
        public string? Password { get; set; }

        [Required]
        public bool Enabled { get; set; }
    }
}
