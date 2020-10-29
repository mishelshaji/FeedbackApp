﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class StaffController : ApiController
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: api/Staff
        public IEnumerable<StudentAndStaff> Get()
        {
            var userManager = HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

            var staffs = _db.Users.Where(m => m.Semester == 0).ToList();
            var staffList = new List<StudentAndStaff>();

            foreach (var s in staffs)
            {
                var role = userManager.GetRoles(s.Id).First();
                if (role != UserRoles.IsStaff)
                    continue;
                var student = new StudentAndStaff()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Role = "Staff",
                    Semester = s.Semester
                };
                staffList.Add(student);
            }

            return staffList;
        }

        // GET: api/Staff/5
        public StudentAndStaff Get(string id)
        {
            var userManager = HttpContext.Current.GetOwinContext()
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
    }
}
