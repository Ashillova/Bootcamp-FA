using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessApp.Models
{
    public class Login
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter Your UserName")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [StringLength(40 ,MinimumLength =8, ErrorMessage ="You need to enter a password with mor then 8 character")]
        [Required(ErrorMessage = "Enter Your Password")]
        public string Password { get; set; }
    }
}