using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiz.Models
{
    public class Interest
    {
        [Required]
        public int InterestId { get; set; }
        [Required]
        public string Questions { get; set; }
        [Required]
        public string Answers { get; set; }
    }
}