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
using APITrivialMaze.Data;
using APITrivialMaze.Models;

namespace APITrivialMaze.Controllers
{
    public class KeyPositionsController : ApiController
    {
        private APITrivialMazeContext db = new APITrivialMazeContext();

        // GET: api/KeyPositions
        public IQueryable<KeyPosition> GetKeyPositions()
        {
            return db.KeyPositions;
        }

        // GET: api/KeyPositions/5
        [ResponseType(typeof(KeyPosition))]
        public IHttpActionResult GetKeyPosition(int id)
        {
            KeyPosition keyPosition = db.KeyPositions.Find(id);
            if (keyPosition == null)
            {
                return NotFound();
            }

            return Ok(keyPosition);
        }

        // PUT: api/KeyPositions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKeyPosition(int id, KeyPosition keyPosition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != keyPosition.ID)
            {
                return BadRequest();
            }

            db.Entry(keyPosition).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyPositionExists(id))
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

        // POST: api/KeyPositions
        [ResponseType(typeof(KeyPosition))]
        public IHttpActionResult PostKeyPosition(KeyPosition keyPosition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KeyPositions.Add(keyPosition);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = keyPosition.ID }, keyPosition);
        }

        // DELETE: api/KeyPositions/5
        [ResponseType(typeof(KeyPosition))]
        public IHttpActionResult DeleteKeyPosition(int id)
        {
            KeyPosition keyPosition = db.KeyPositions.Find(id);
            if (keyPosition == null)
            {
                return NotFound();
            }

            db.KeyPositions.Remove(keyPosition);
            db.SaveChanges();

            return Ok(keyPosition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KeyPositionExists(int id)
        {
            return db.KeyPositions.Count(e => e.ID == id) > 0;
        }
    }
}