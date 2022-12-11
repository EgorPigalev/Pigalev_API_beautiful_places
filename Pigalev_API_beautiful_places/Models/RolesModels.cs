using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Pigalev_API_beautiful_places.Models
{
    public class RolesModels
    {
        public int id_role { get; set; }
        public string role { get; set; }
        public RolesModels(Roles roles)
        {
            id_role = roles.id_role;
            role = roles.role;
        }
    }
}