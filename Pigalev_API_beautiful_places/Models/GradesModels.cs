using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pigalev_API_beautiful_places.Models
{
    public class GradesModels
    {
        public int id_grade { get; set; }
        public int id_user { get; set; }
        public int id_beautiful_place { get; set; }
        public GradesModels(GradesModels gradesModels)
        {
            id_grade = gradesModels.id_grade;
            id_user = gradesModels.id_user;
            id_beautiful_place = gradesModels.id_beautiful_place;
        }
    }
}