using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FeedbackApp.Models;
using FeedbackApp.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace FeedbackApp.Controllers
{
    public class UserController : ApiController
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: api/Student
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Student/5
        //[Route("GetUserById")]
        public StudentAndStaff Get(string id)
        {
            var userManager = HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();
            var roleManage = HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();
            var user = userManager.FindById(id);
            
            if (user != null)
            {
                var role = userManager.GetRoles(id);

                var ss = new StudentAndStaff()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Semester = user.Semester,
                    Role = role[0]
                };
                return ss;
            }

            return null;
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
