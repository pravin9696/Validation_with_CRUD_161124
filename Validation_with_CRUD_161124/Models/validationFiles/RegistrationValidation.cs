using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Validation_with_CRUD_161124.Models.validationFiles
{
    public class RegistrationValidation
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(5)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(5)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6,ErrorMessage ="Atleast 6 char password requried!!")]
        public string Password { get; set; }
    }
}