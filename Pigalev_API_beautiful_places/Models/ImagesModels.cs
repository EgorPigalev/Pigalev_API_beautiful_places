using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Pigalev_API_beautiful_places.Models
{
    public class ImagesModels
    {
        public int id_image { get; set; }
        public string image { get; set; }
        public int id_beautiful_place { get; set; }
        public ImagesModels(Images images)
        {
            id_image = images.id_image;
            image = images.image;
            id_beautiful_place = images.id_beautiful_place;
        }
    }
}