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
    public class TypeLocalitysController : ApiController
    {
        private BaseData db = new BaseData();

        // GET: api/TypeLocalitys
        [ResponseType(typeof(List<TypeLocalitysModels>))]
        public IHttpActionResult GetTypeLocalitys()
        {
            return Ok(db.TypeLocalitys.ToList().ConvertAll(x => new TypeLocalitysModels(x)));
        }

        // GET: api/TypeLocalitys/5
        [ResponseType(typeof(TypeLocalitys))]
        public IHttpActionResult GetTypeLocalitys(int id)
        {
            TypeLocalitys typeLocalitys = db.TypeLocalitys.Find(id);
            if (typeLocalitys == null)
            {
                return NotFound();
            }

            return Ok(typeLocalitys);
        }

        // PUT: api/TypeLocalitys/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeLocalitys(int id, TypeLocalitys typeLocalitys)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeLocalitys.id_type_locality)
            {
                return BadRequest();
            }

            db.Entry(typeLocalitys).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeLocalitysExists(id))
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

        // POST: api/TypeLocalitys
        [ResponseType(typeof(TypeLocalitys))]
        public IHttpActionResult PostTypeLocalitys(TypeLocalitys typeLocalitys)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeLocalitys.Add(typeLocalitys);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeLocalitys.id_type_locality }, typeLocalitys);
        }

        // DELETE: api/TypeLocalitys/5
        [ResponseType(typeof(TypeLocalitys))]
        public IHttpActionResult DeleteTypeLocalitys(int id)
        {
            TypeLocalitys typeLocalitys = db.TypeLocalitys.Find(id);
            if (typeLocalitys == null)
            {
                return NotFound();
            }

            db.TypeLocalitys.Remove(typeLocalitys);
            db.SaveChanges();

            return Ok(typeLocalitys);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeLocalitysExists(int id)
        {
            return db.TypeLocalitys.Count(e => e.id_type_locality == id) > 0;
        }
    }
}