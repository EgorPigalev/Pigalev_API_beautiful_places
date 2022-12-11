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
        public GradesModels(Grades grades)
        {
            id_grade = grades.id_grade;
            id_user = grades.id_user;
            id_beautiful_place = grades.id_beautiful_place;
        }
    }
}