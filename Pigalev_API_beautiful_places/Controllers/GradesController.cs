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

        public GradesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Grades
        [ResponseType(typeof(List<GradesModels>))]
        public IHttpActionResult GetPhones()
        {
            return Ok(db.Grades.ToList().ConvertAll(x => new GradesModels(x)));
        }

        [Route("api/Grades/countGrades")]
        [HttpGet]
        public int countGrades(int id_beautifulPlace)
        {
            List<Grades> grades = db.Grades.Where(x => x.id_beautiful_place == id_beautifulPlace).ToList();
            return grades.Count;
        }


        [Route("api/Grades/proverkaGrades")]
        [HttpGet]
        public bool proverkaFavorite(int id_beautifulPlace, int id_user)
        {
            List<Grades> grades = db.Grades.Where(x => x.id_user == id_user).ToList();
            grades = grades.Where(x => x.id_beautiful_place == id_beautifulPlace).ToList();
            if (grades.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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

        [Route("api/Grades/deleteGrades")]
        [HttpDelete]
        public IHttpActionResult deleteGrades(int id_beautifulPlace, int id_user)
        {
            Grades grades = db.Grades.FirstOrDefault(x => x.id_user == id_user && x.id_beautiful_place == id_beautifulPlace);
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