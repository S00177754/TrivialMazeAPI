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
    public class TriviaQuestionsController : ApiController
    {
        private TrivialMazeAPIContext db = new TrivialMazeAPIContext();

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