﻿using System;
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
        public IEnumerable<StudentViewModel> Get()
        {
            var userManager = HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

            var students = _db.Users.Where(m => m.Semester > 0).ToList();
            var studentList = new List<StudentViewModel>();

            foreach (var s in students)
            {
                var student = new StudentViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Role = "Student",
                    Semester = s.Semester,
                    Email = s.Email,
                    Batch = s.Batch
                };
                studentList.Add(student);
            }

            return studentList;
        }

        // GET: api/Student/5
        public StudentViewModel Get(string id)
        {
            var userManager = HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();
            var user = userManager.FindById(id);

            if (user != null)
            {
                var role = userManager.GetRoles(id).First();
                if (role != UserRoles.IsStudent)
                {
                    return null;
                }
                var ss = new StudentViewModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Semester = user.Semester,
                    Role = role,
                    DepartmentId = user.DepartmentId,
                    Email = user.Email,
                    Batch = user.Batch,
                };
                return ss;
            }

            return null;
        }
    }
}
