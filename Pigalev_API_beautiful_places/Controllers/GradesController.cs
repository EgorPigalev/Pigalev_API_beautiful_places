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
using Pigalev_API_beautiful_places.Models;

namespace Pigalev_API_beautiful_places.Controllers
{
    public class GradesController : ApiController
    {
        private BaseData db = new BaseData();

        // GET: api/Grades
        [ResponseType(typeof(List<GradesModels>))]
        public IHttpActionResult GetPhones()
        {
            return Ok(db.Grades.ToList().ConvertAll(x => new GradesModels(x)));
        }

        // GET: api/Grades/5
        [ResponseType(typeof(Grades))]
        public IHttpActionResult GetGrades(int id)
        {
            Grades grades = db.Grades.Find(id);
            if (grades == null)
            {
                return NotFound();
            }

            return Ok(grades);
        }

        // PUT: api/Grades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrades(int id, Grades grades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grades.id_grade)
            {
                return BadRequest();
            }

            db.Entry(grades).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradesExists(id))
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

        // POST: api/Grades
        [ResponseType(typeof(Grades))]
        public IHttpActionResult PostGrades(Grades grades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grades.Add(grades);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = grades.id_grade }, grades);
        }

        // DELETE: api/Grades/5
        [ResponseType(typeof(Grades))]
        public IHttpActionResult DeleteGrades(int id)
        {
            Grades grades = db.Grades.Find(id);
            if (grades == null)
            {
                return NotFound();
            }

            db.Grades.Remove(grades);
            db.SaveChanges();

            return Ok(grades);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GradesExists(int id)
        {
            return db.Grades.Count(e => e.id_grade == id) > 0;
        }
    }
}