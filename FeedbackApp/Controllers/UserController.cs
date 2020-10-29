using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        // POST: api/User
        //[Route("Login")]
        public StudentAndStaff Post(Login login)
        {
            var userManager = HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByEmail(login.Email);
            var res = userManager.PasswordHasher.VerifyHashedPassword(user.PasswordHash, login.Password);
            if (res == PasswordVerificationResult.Success)
            {
                var role = userManager.GetRoles(user.Id).First();
                return new StudentAndStaff()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Semester = user.Semester,
                    Role = role
                };
            }
            return new StudentAndStaff();
        }

        // PUT: api/User/5
        public string Put(string id, UserProfile profile)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.FirstOrDefault(m => m.Id == id);
                if (user != null)
                {
                    user.Email = profile.Email;
                    user.UserName = profile.Email;
                    user.Name = profile.Name;
                    user.Semester = profile.Semester;
                    _db.Users.AddOrUpdate(user);
                    _db.SaveChanges();
                    return "ok";
                }
            }
            return "no";
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
