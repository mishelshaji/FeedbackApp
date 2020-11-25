using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FeedbackApp.Models;
using FeedbackApp.Models.ViewModels;

namespace FeedbackApp.Controllers
{
    public class FacultyController : ApiController
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        // GET: api/Faculty/5
        public ICollection<FeedbackView> Get(string StaffId)
        {
            var feedbacks = _db.Feedbacks.Where(m => m.TeacherId == StaffId).ToList();
            var feedbackList = new List<FeedbackView>();
            foreach (var i in feedbacks)
            {
                var subject = _db.Subjects.FirstOrDefault(m => m.Id == i.SubjectId);
                if (subject == null)
                {
                    continue;
                }
                feedbackList.Add(new FeedbackView()
                {
                    Id = i.Id,
                    Comment = i.Comment,
                    StudentId = i.StudentId,
                    PostedOn = i.PostedOn,
                    TeacherId = i.TeacherId,
                    SubjectName = subject.SubjectName,
                    Option1 = i.Option1,
                    Option2 = i.Option2,
                    Option3 = i.Option3,
                    Option4 = i.Option4,
                    Option5 = i.Option5,
                    Option6 = i.Option6,
                    Option7 = i.Option7,
                    Option8 = i.Option8,
                    Option9 = i.Option9,
                });
            }

            return feedbackList;
        }
    }
}
