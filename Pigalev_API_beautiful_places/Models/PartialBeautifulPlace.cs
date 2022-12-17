
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pigalev_API_beautiful_places.Models
{
    public partial class BeautifulPlace
    {
        private BaseData db = new BaseData();

        public int CountGrade
        {
            get
            {
                List<Grades> grades = db.Grades.Where(x => x.id_beautiful_place == id_beautiful_place).ToList();
                return grades.Count;
            }
        }
    }
}