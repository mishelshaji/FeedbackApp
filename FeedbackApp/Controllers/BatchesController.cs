using System;
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
    public class BatchesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Batches
        public IQueryable<Batch> GetBatches()
        {
            return db.Batches;
        }

        // GET: api/Batches/5
        [ResponseType(typeof(Batch))]
        public async Task<IHttpActionResult> GetBatch(int id)
        {
            Batch batch = await db.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }

            return Ok(batch);
        }

        // PUT: api/Batches/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBatch(int id, Batch batch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != batch.Id)
            {
                return BadRequest();
            }

            db.Entry(batch).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatchExists(id))
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

        // POST: api/Batches
        [ResponseType(typeof(Batch))]
        public async Task<IHttpActionResult> PostBatch(Batch batch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Batches.Add(batch);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = batch.Id }, batch);
        }

        // DELETE: api/Batches/5
        [ResponseType(typeof(Batch))]
        public async Task<IHttpActionResult> DeleteBatch(int id)
        {
            Batch batch = await db.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }

            db.Batches.Remove(batch);
            await db.SaveChangesAsync();

            return Ok(batch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BatchExists(int id)
        {
            return db.Batches.Count(e => e.Id == id) > 0;
        }
    }
}