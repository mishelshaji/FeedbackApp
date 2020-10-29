using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FeedbackApp.Models.ViewModels
{
    public class UserProfile
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Semester { get; set; }

        [Required]
        public string Email { get; set; }
    }
}