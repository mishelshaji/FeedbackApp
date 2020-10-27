using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FeedbackApp.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(10)]
        public string StudentId { get; set; }

        [MinLength(10)]
        public string TeacherId { get; set; }
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