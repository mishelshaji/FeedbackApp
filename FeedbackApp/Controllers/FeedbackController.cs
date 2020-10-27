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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using FeedbackApp.Models;

namespace FeedbackApp.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using FeedbackApp.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Feedback>("Feedback");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class FeedbackController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/Feedback
        [EnableQuery]
        public IQueryable<Feedback> GetFeedback()
        {
            return db.Feedbacks;
        }

        // GET: odata/Feedback(5)
        [EnableQuery]
        public SingleResult<Feedback> GetFeedback([FromODataUri] int key)
        {
            return SingleResult.Create(db.Feedbacks.Where(feedback => feedback.Id == key));
        }

        // PUT: odata/Feedback(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Feedback> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Feedback feedback = await db.Feedbacks.FindAsync(key);
            if (feedback == null)
            {
                return NotFound();
            }

            patch.Put(feedback);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(feedback);
        }

        // POST: odata/Feedback
        public async Task<IHttpActionResult> Post(Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Feedbacks.Add(feedback);
            await db.SaveChangesAsync();

            return Created(feedback);
        }

        // PATCH: odata/Feedback(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Feedback> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Feedback feedback = await db.Feedbacks.FindAsync(key);
            if (feedback == null)
            {
                return NotFound();
            }

            patch.Patch(feedback);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(feedback);
        }

        // DELETE: odata/Feedback(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Feedback feedback = await db.Feedbacks.FindAsync(key);
            if (feedback == null)
            {
                return NotFound();
            }

            db.Feedbacks.Remove(feedback);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeedbackExists(int key)
        {
            return db.Feedbacks.Count(e => e.Id == key) > 0;
        }
    }
}
