using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pigalev_API_beautiful_places.Models
{
    public class AdressModels
    {
        public int id_address { get; set; }
        public string country { get; set; }
        public string locality { get; set; }
        public AdressModels(Address address)
        {
            id_address = address.id_address;
            country = address.country;
            locality = address.locality;
        }
    }
}