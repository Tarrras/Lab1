using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public static class ExctensionLecturer
    {
        public static List<Lecturer> SoringDictionary(this LecturerCollection<string> lecturerCollection)
        {
            var temp = new Lecturer();
            List<Lecturer> lecturers = lecturerCollection.keyValuePairs.Values.ToList();
            lecturers.Sort((a, b) => a.Raiting.CompareTo(b.Raiting) * -1);
            return lecturers;
        }
    }
}
