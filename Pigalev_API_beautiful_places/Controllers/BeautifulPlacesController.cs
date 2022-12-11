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
    public class BeautifulPlacesController : ApiController
    {
        private BaseData db = new BaseData();

        // GET: api/BeautifulPlaces
        [ResponseType(typeof(List<BeautifukPlacesModel>))]
        public IHttpActionResult GetPhones()
        {
            return Ok(db.BeautifulPlace.ToList().ConvertAll(x => new BeautifukPlacesModel(x)));
        }

        // GET: api/BeautifulPlaces/5
        [ResponseType(typeof(BeautifulPlace))]
        public IHttpActionResult GetBeautifulPlace(int id)
        {
            BeautifulPlace beautifulPlace = db.BeautifulPlace.Find(id);
            if (beautifulPlace == null)
            {
                return NotFound();
            }

            return Ok(beautifulPlace);
        }

        // PUT: api/BeautifulPlaces/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBeautifulPlace(int id, BeautifulPlace beautifulPlace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != beautifulPlace.id_beautiful_place)
            {
                return BadRequest();
            }

            db.Entry(beautifulPlace).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeautifulPlaceExists(id))
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

        // POST: api/BeautifulPlaces
        [ResponseType(typeof(BeautifulPlace))]
        public IHttpActionResult PostBeautifulPlace(BeautifulPlace beautifulPlace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BeautifulPlace.Add(beautifulPlace);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = beautifulPlace.id_beautiful_place }, beautifulPlace);
        }

        // DELETE: api/BeautifulPlaces/5
        [ResponseType(typeof(BeautifulPlace))]
        public IHttpActionResult DeleteBeautifulPlace(int id)
        {
            BeautifulPlace beautifulPlace = db.BeautifulPlace.Find(id);
            if (beautifulPlace == null)
            {
                return NotFound();
            }

            db.BeautifulPlace.Remove(beautifulPlace);
            db.SaveChanges();

            return Ok(beautifulPlace);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BeautifulPlaceExists(int id)
        {
            return db.BeautifulPlace.Count(e => e.id_beautiful_place == id) > 0;
        }
    }
}