using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedbackApp.Models.ViewModels
{
    public class StudentAndStaff
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public string Role { get; set; }
    }
}