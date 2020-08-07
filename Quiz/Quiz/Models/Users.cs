using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quiz.Models
{
    [Table("UserDetails")]
    public class Users
    {
        [Required]
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int MobileNumber { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}