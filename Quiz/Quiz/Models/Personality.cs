using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiz.Models
{
    public class Personality
    {
        [Required]
        public int personalityId { get; set; }
        [Required]
        public string Questions { get; set; }
        [Required]
        public string Answers { get; set; }
    }
}