using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pigalev_API_beautiful_places.Models
{
    public class UsersModels
    {
        public int id_user { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int id_role { get; set; }

        public UsersModels(Users users)
        {
            id_user = users.id_user;
            login = users.login;
            password = users.password;
            id_role = users.id_role;
        }
    }
}