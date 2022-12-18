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

        public BeautifulPlacesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/BeautifulPlaces
        [ResponseType(typeof(List<BeautifukPlacesModel>))]
        public IHttpActionResult GetBeautifulPlace()
        {
            return Ok(db.BeautifulPlace.ToList().ConvertAll(x => new BeautifukPlacesModel(x)));
        }

        // GET: api/BeautifulPlaces
        [ResponseType(typeof(List<BeautifukPlacesModel>))]
        public IHttpActionResult GetBeautifulPlaceUser(int id, bool b)
        {
            List<BeautifulPlace> beautifulPlaces = db.BeautifulPlace.Where(x => x.id_user == id).ToList();
            beautifulPlaces = beautifulPlaces.Where(x => x.accepted == b).ToList();
            return Ok(beautifulPlaces.ConvertAll(x => new BeautifukPlacesModel(x)));
        }

        // GET: api/BeautifulPlaces
        [ResponseType(typeof(List<BeautifukPlacesModel>))]
        public IHttpActionResult GetBeautifulPlace(bool b, string name, int id_address, int id_type_locality, string fieldSort, string valueSort) // Метод для поиска и сортировки
        {
            List<BeautifulPlace> beautifulPlaces = db.BeautifulPlace.Where(x => x.accepted == b).ToList();
            if (!string.IsNullOrWhiteSpace(name))  // если строка не пустая и если она не состоит из пробелов
            {
                beautifulPlaces = beautifulPlaces.Where(x => x.name.ToLower().Contains(name.ToLower())).ToList();
            }
            if(id_address != 0) // Фильтрация по стране
            {
                beautifulPlaces = beautifulPlaces.Where(x => x.id_address == id_address).ToList();
            }
            if (id_type_locality != 0) // Фильтрация по типу места
            {
                beautifulPlaces = beautifulPlaces.Where(x => x.id_type_locality == id_type_locality).ToList();
            }
            if (fieldSort != null) // Сортировка
            {
                Sorting(beautifulPlaces, fieldSort, valueSort);
            }
            return Ok(beautifulPlaces.ConvertAll(x => new BeautifukPlacesModel(x)));
        }

        public List<BeautifulPlace> Sorting(List<BeautifulPlace> beautifulPlaces, string fieldSort, string valueSort) // Метод для сортировки
        {
            switch (fieldSort)
            {
                case ("По наименованию"):
                    if (valueSort == "Возрастание")
                    {
                        beautifulPlaces.Sort((x, y) => x.name.CompareTo(y.name));
                    }
                    else
                    {
                        beautifulPlaces.Sort((x, y) => x.name.CompareTo(y.name));
                        beautifulPlaces.Reverse();
                    }
                    break;
                case ("По популярности"):
                    if (valueSort == "Возрастание")
                    {
                        beautifulPlaces.Sort((x, y) => x.CountGrade.CompareTo(y.CountGrade));
                    }
                    else
                    {
                        beautifulPlaces.Sort((x, y) => x.CountGrade.CompareTo(y.CountGrade));
                        beautifulPlaces.Reverse();
                    }
                    break;
            }
            return beautifulPlaces;
        }

        // GET: api/BeautifulPlaces
        [ResponseType(typeof(List<BeautifukPlacesModel>))]
        public IHttpActionResult GetBeautifulPlaceFavorite(int id_user)
        {
            List<Favorites> favorites = db.Favorites.Where(x => x.id_user == id_user).ToList();

            List<BeautifulPlace> beautifulPlaces = new List<BeautifulPlace>();

            foreach (Favorites favorite in favorites)
            {
                BeautifulPlace beautifulPlace = db.BeautifulPlace.FirstOrDefault(x => x.id_beautiful_place == favorite.id_beautiful_place);
                beautifulPlaces.Add(beautifulPlace);
            }

            return Ok(beautifulPlaces.ConvertAll(x => new BeautifukPlacesModel(x)));
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
            BeautifulPlace beautiful = db.BeautifulPlace.FirstOrDefault(x => x.id_beautiful_place.Equals(id));

            beautiful.name = beautifulPlace.name;
            beautiful.description = beautifulPlace.description;
            beautiful.id_address = beautifulPlace.id_address;
            beautiful.id_type_locality = beautifulPlace.id_type_locality;
            beautiful.latitude = beautifulPlace.latitude;
            beautiful.longitude = beautifulPlace.longitude;
            if (beautiful.image == "null")
            {
                beautiful.image = null;
            }
            else
            {
                beautiful.image = beautifulPlace.image;
            }
            beautiful.accepted = true;
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