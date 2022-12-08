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
    public class ImagesController : ApiController
    {
        private BaseData db = new BaseData();

        // GET: api/Images
        public IQueryable<Images> GetImages()
        {
            return db.Images;
        }

        // GET: api/Images/5
        [ResponseType(typeof(Images))]
        public IHttpActionResult GetImages(int id)
        {
            Images images = db.Images.Find(id);
            if (images == null)
            {
                return NotFound();
            }

            return Ok(images);
        }

        // PUT: api/Images/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImages(int id, Images images)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != images.id_image)
            {
                return BadRequest();
            }

            db.Entry(images).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagesExists(id))
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

        // POST: api/Images
        [ResponseType(typeof(Images))]
        public IHttpActionResult PostImages(Images images)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Images.Add(images);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = images.id_image }, images);
        }

        // DELETE: api/Images/5
        [ResponseType(typeof(Images))]
        public IHttpActionResult DeleteImages(int id)
        {
            Images images = db.Images.Find(id);
            if (images == null)
            {
                return NotFound();
            }

            db.Images.Remove(images);
            db.SaveChanges();

            return Ok(images);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImagesExists(int id)
        {
            return db.Images.Count(e => e.id_image == id) > 0;
        }
    }
}