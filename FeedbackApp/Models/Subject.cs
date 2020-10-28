using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FeedbackApp.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public int Semester { get; set; }

        public string TeacherId { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}