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
    public class UsersController : ApiController
    {
        private BaseData db = new BaseData();

        public UsersController()
        {

            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Users
        [ResponseType(typeof(List<UsersModels>))]
        public IHttpActionResult GetUsers()
        {
            return Ok(db.Users.ToList().ConvertAll(x => new UsersModels(x)));
        }

        // GET: api/Users
        [ResponseType(typeof(List<UsersModels>))] // Метод для проверки наличия пользователя в базе
        public bool GetUsersRegistration(string login)
        {
            List<Users> users = db.Users.Where(x => x.login == login).ToList();
            if(users.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        // GET: api/Users
        [ResponseType(typeof(List<UsersModels>))] // Метод для определения количества добавленных мест пользователем
        public int GetUsersRegistration(int id_user)
        {
            List<BeautifulPlace> beautifulPlaces = db.BeautifulPlace.Where(x => x.id_user == id_user).ToList();
            beautifulPlaces = beautifulPlaces.Where(x => x.accepted == true).ToList();
            return beautifulPlaces.Count;
        }
        

        // GET: api/Users
        [ResponseType(typeof(List<UsersModels>))] // Метод для авторизации
        public Users GetUsersLogin(string login, string password)
        {
            List<Users> users = db.Users.Where(x => x.login == login).ToList();
            string strPassword = Convert.ToString(password.GetHashCode());
            Users user = users.FirstOrDefault(x => x.password == strPassword);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users users)
        {
            Users user = db.Users.FirstOrDefault(x => x.id_user.Equals(id));

            user.login = users.login;
            if(user.password != users.password)
            {
                user.password = Convert.ToString(users.password.GetHashCode());
            }
            if (users.image == "null")
            {
                user.image = null;
            }
            else
            {
                user.image = users.image;
            }
            user.id_role = users.id_role;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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


        // POST: api/Users
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            users.password = Convert.ToString(users.password.GetHashCode());
            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.id_user }, users);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.id_user == id) > 0;
        }
    }
}