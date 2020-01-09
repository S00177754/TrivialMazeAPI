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
    public class PlayersController : ApiController
    {
        private APITrivialMazeContext db = new APITrivialMazeContext();

        // GET: api/Players
        //public IQueryable<Player> GetPlayers()
        //{
        //    return db.Players;
        //}

        // GET: api/Players/5
        //[ResponseType(typeof(Player))]
        //public IHttpActionResult GetPlayer(Guid id)
        //{
        //    Player player = db.Players.Find(id);
        //    if (player == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(player);
        //}

        [ResponseType(typeof(Player))]
        public IHttpActionResult GetPlayer(string username)
        {
            Player player = db.Players.Where(p => p.Username == username).SingleOrDefault();
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        //// PUT: api/Players/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPlayer(Guid id, Player player)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != player.PlayerID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(player).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlayerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Players
        [ResponseType(typeof(Player))]
        public IHttpActionResult PostPlayer(Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Players.Add(player);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PlayerExists(player.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = player.Username }, player);
        }

        // DELETE: api/Players/5
        [ResponseType(typeof(Player))]
        public IHttpActionResult DeletePlayer(Guid id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            db.SaveChanges();

            return Ok(player);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerExists(string username)
        {
            return db.Players.Count(e => e.Username == username) > 0;
        }
    }
}