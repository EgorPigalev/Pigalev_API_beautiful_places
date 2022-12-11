using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace Pigalev_API_beautiful_places.Models
{
    public class TypeLocalitysModels
    {
        public int id_type_locality { get; set; }
        public string type_locality { get; set; }
        public TypeLocalitysModels(TypeLocalitys typeLocalitys)
        {
            id_type_locality = typeLocalitys.id_type_locality;
            type_locality = typeLocalitys.type_locality;
        }
    }
}