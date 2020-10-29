using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FeedbackApp.Models;
using FeedbackApp.Models.ViewModels;
using FeedbackApp.Shared;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace FeedbackApp.Controllers
{
    public class StudentController : ApiController
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: api/Student
        public IEnumerable<StudentAndStaff> Get()
        {
            var userManager = HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

            var students = _db.Users.Where(m => m.Semester > 0).ToList();
            var studentList = new List<StudentAndStaff>();

            foreach (var s in students)
            {
                var student = new StudentAndStaff()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Role = "Staff",
                    Semester = s.Semester
                };
                studentList.Add(student);
            }

            return studentList;
        }

        // GET: api/Student/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Student
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
        }
    }
}
