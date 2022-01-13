using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessApp.Models
{
    public class SignUp
    {
        
        public int ID { get; set; }
        [Required(ErrorMessage = "Please complite this Textbox")]
        public string Firstname { get; set; }
        [Required (ErrorMessage = "Please complite this Textbox")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Please complite this Textbox")]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please complite this Textbox")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "You need to write longer Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Please write same Password")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}