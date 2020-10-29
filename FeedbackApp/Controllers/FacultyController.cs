using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FeedbackApp.Models;

namespace FeedbackApp.Controllers
{
    public class FacultyController : ApiController
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        // GET: api/Faculty/5
        public ICollection<Feedback> Get(string StaffId)
        {
            var feedback = _db.Feedbacks.Where(m => m.TeacherId == StaffId).ToList();
            return feedback;
        }
    }
}
