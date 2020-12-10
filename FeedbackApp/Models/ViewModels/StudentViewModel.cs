using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedbackApp.Models.ViewModels
{
    public class StudentViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public string Role { get; set; }
        public int DepartmentId { get; set; }
        public string Email { get; set; }
        public int Batch { get; set; }
    }
}