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
using APITrivialMaze.Data;
using APITrivialMaze.Models;

namespace APITrivialMaze.Controllers
{
    public class TriviaQuestionsController : ApiController
    {
        private APITrivialMazeContext db = new APITrivialMazeContext();

        // GET: api/TriviaQuestions
        public IQueryable<TriviaQuestion> GetTriviaQuestions()
        {
            return db.TriviaQuestions;
        }

        // GET: api/TriviaQuestions/5
        [ResponseType(typeof(TriviaQuestion))]
        public IHttpActionResult GetTriviaQuestion(int id)
        {
            TriviaQuestion triviaQuestion = db.TriviaQuestions.Find(id);
            if (triviaQuestion == null)
            {
                return NotFound();
            }

            return Ok(triviaQuestion);
        }

        // PUT: api/TriviaQuestions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTriviaQuestion(int id, TriviaQuestion triviaQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != triviaQuestion.ID)
            {
                return BadRequest();
            }

            db.Entry(triviaQuestion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TriviaQuestionExists(id))
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

        // POST: api/TriviaQuestions
        [ResponseType(typeof(TriviaQuestion))]
        public IHttpActionResult PostTriviaQuestion(TriviaQuestion triviaQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TriviaQuestions.Add(triviaQuestion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = triviaQuestion.ID }, triviaQuestion);
        }

        // DELETE: api/TriviaQuestions/5
        [ResponseType(typeof(TriviaQuestion))]
        public IHttpActionResult DeleteTriviaQuestion(int id)
        {
            TriviaQuestion triviaQuestion = db.TriviaQuestions.Find(id);
            if (triviaQuestion == null)
            {
                return NotFound();
            }

            db.TriviaQuestions.Remove(triviaQuestion);
            db.SaveChanges();

            return Ok(triviaQuestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TriviaQuestionExists(int id)
        {
            return db.TriviaQuestions.Count(e => e.ID == id) > 0;
        }
    }
}