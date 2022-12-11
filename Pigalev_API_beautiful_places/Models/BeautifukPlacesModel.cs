using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pigalev_API_beautiful_places.Models
{
    public class BeautifukPlacesModel
    {
        public int id_beautiful_place { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int id_user { get; set; }
        public int id_address { get; set; }
        public int id_type_locality { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string main_image { get; set; }
        public bool accepted { get; set; }


        public BeautifukPlacesModel(BeautifulPlace beautifulPlace)
        {
            id_beautiful_place = beautifulPlace.id_beautiful_place;
            name = beautifulPlace.name;
            description = beautifulPlace.description;
            id_user = beautifulPlace.id_user;
            id_address = beautifulPlace.id_address;
            id_type_locality = beautifulPlace.id_type_locality;
            latitude = (float)beautifulPlace.latitude;
            longitude = (float)beautifulPlace.longitude;
            main_image = beautifulPlace.main_image;
            accepted = beautifulPlace.accepted;
        }
    }
}