using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public static class ExctensionLecturer
    {
        public static List<Lecturer> SoringDictionary(this  LecturerCollection<string> lecturerCollection)
        {
            var temp = new Lecturer();
            List<Lecturer> lecturers = lecturerCollection.keyValuePairs.Values.ToList();
            for(int i = 0; i < lecturers.Count; i++)
            {
                for(int j = 0; j < lecturers.Count - 1; j++)
                {
                    if (lecturers[j].Raiting < lecturers[j + 1].Raiting)
                    {
                        temp = lecturers[j];
                        lecturers[j] = lecturers[j + 1];
                        lecturers[j + 1] = temp;
                    }
                }
            }
            return lecturers;
        }
    }
}
