﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APITrivialMaze.Classes;
using APITrivialMaze.Data;
using APITrivialMaze.Models;

namespace APITrivialMaze.Controllers
{
    public class TimeScoresController : ApiController
    {
        private APITrivialMazeContext db = new APITrivialMazeContext();

        //// GET: api/TimeScores
        //public IQueryable<TimeScore> GetTimeScores()
        //{
        //    return db.TimeScores;
        //}

        //// GET: api/TimeScores/5
        //[ResponseType(typeof(TimeScore))]
        //public IHttpActionResult GetTimeScore(int id)
        //{
        //    TimeScore timeScore = db.TimeScores.Find(id);
        //    if (timeScore == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(timeScore);
        //}

        //// PUT: api/TimeScores/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutTimeScore(int id, TimeScore timeScore)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != timeScore.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(timeScore).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TimeScoreExists(id))
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

        // GET
        [ResponseType(typeof(List<TimeScoreResponse>))]
        public IHttpActionResult GetTimeScore(int amount)
        {
            List<TimeScore> timeScores = db.TimeScores.OrderBy(n => n.Time).Take(amount).ToList();
            List<TimeScoreResponse> response = new List<TimeScoreResponse>();
            foreach (var item in timeScores)
            {
                response.Add(new TimeScoreResponse() { ID = item.ID, PlayerUsername = item.PlayerUsername, Time = item.Time });
            }

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [ResponseType(typeof(List<TimeScoreResponse>))]
        public IHttpActionResult GetTimeScore(string username)
        {
            List<TimeScore> timeScores = db.TimeScores.OrderBy(n => n.Time).Where(n => n.PlayerUsername == username).Take(10).ToList();
            List<TimeScoreResponse> response = new List<TimeScoreResponse>();
            foreach (var item in timeScores)
            {
                response.Add(new TimeScoreResponse() { ID = item.ID, PlayerUsername = item.PlayerUsername, Time = item.Time });
            }

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        //// DELETE: api/TimeScores/5
        //[ResponseType(typeof(TimeScore))]
        //public IHttpActionResult DeleteTimeScore(int id)
        //{
        //    TimeScore timeScore = db.TimeScores.Find(id);
        //    if (timeScore == null)
        //    {
        //        return NotFound();
        //    }

        //    db.TimeScores.Remove(timeScore);
        //    db.SaveChanges();

        //    return Ok(timeScore);
        //}

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

