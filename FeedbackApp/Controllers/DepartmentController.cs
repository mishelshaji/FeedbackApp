﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FeedbackApp.Models;

namespace FeedbackApp.Controllers
{
    public class DepartmentController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Department
        public IQueryable<Department> GetDepartments()
        {
            return db.Departments;
        }

        // GET: api/Department/5
        [ResponseType(typeof(Department))]
        public async Task<IHttpActionResult> GetDepartment(int id)
        {
            Department department = await db.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // PUT: api/Department/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDepartment(int id, Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.Id)
            {
                return BadRequest();
            }

            db.Entry(department).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Department
        [ResponseType(typeof(Department))]
        public async Task<IHttpActionResult> PostDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departments.Add(department);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = department.Id }, department);
        }

        // DELETE: api/Department/5
        [ResponseType(typeof(Department))]
        public async Task<IHttpActionResult> DeleteDepartment(int id)
        {
            Department department = await db.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            db.Departments.Remove(department);
            await db.SaveChangesAsync();

            return Ok(department);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentExists(int id)
        {
            return db.Departments.Count(e => e.Id == id) > 0;
        }
    }
}