using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FeedbackApp.Models;

namespace FeedbackApp.Controllers
{
    public class SemesterController : ApiController
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: api/Semester/5
        public ICollection<string> Get(int id)
        {
            var semester = _db.Subjects.Where(m => m.Semester == id).ToList();
            var subjects = new List<string>();
            foreach (var s in semester)
            {
                subjects.Add(s.SubjectName);
            }

            return subjects;
        }
    }
}
