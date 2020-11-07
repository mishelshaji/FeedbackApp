using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FeedbackApp.Models;

namespace FeedbackApp.Controllers
{
    public class DepartmentSubjectController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/StudentSubject/5
        public IEnumerable<Subject> Get(int departmentId)
        {
            var dept = db.Subjects.Where(m => m.DepartmentId == departmentId).ToList();
            return dept;
        }
    }
}
