using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TrivialMazeAPI.Models;

namespace TrivialMazeAPI.Controllers
{
    public class TimeScoresController : ApiController
    {
        private TrivialMazeAPIContext db = new TrivialMazeAPIContext();

        // GET: api/TimeScores
        public IQueryable<TimeScore> GetTimeScores()
        {
            return db.TimeScores;
        }

        // GET: api/TimeScores/5
        [ResponseType(typeof(TimeScore))]
        public IHttpActionResult GetTimeScore(int id)
        {
            TimeScore timeScore = db.TimeScores.Find(id);
            if (timeScore == null)
            {
                return NotFound();
            }

            return Ok(timeScore);
        }

        // PUT: api/TimeScores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTimeScore(int id, TimeScore timeScore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timeScore.ID)
            {
                return BadRequest();
            }

            db.Entry(timeScore).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeScoreExists(id))
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

        // POST: api/TimeScores
        [ResponseType(typeof(TimeScore))]
        public IHttpActionResult PostTimeScore(TimeScore timeScore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TimeScores.Add(timeScore);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = timeScore.ID }, timeScore);
        }

        // DELETE: api/TimeScores/5
        [ResponseType(typeof(TimeScore))]
        public IHttpActionResult DeleteTimeScore(int id)
        {
            TimeScore timeScore = db.TimeScores.Find(id);
            if (timeScore == null)
            {
                return NotFound();
            }

            db.TimeScores.Remove(timeScore);
            db.SaveChanges();

            return Ok(timeScore);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeScoreExists(int id)
        {
            return db.TimeScores.Count(e => e.ID == id) > 0;
        }
    }
}