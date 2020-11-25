using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedbackApp.Models.ViewModels
{
    public class FeedbackView
    {
        public int Id { get; set; }

        public string StudentId { get; set; }

        public string TeacherId { get; set; }

        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public DateTime PostedOn { get; set; }

        public int Option1 { get; set; }
        public int Option2 { get; set; }
        public int Option3 { get; set; }
        public int Option4 { get; set; }
        public int Option5 { get; set; }
        public int Option6 { get; set; }
        public int Option7 { get; set; }
        public int Option8 { get; set; }
        public int Option9 { get; set; }
        public string Comment { get; set; }
    }
}