using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public class LecturerCollection:Lecturer
    {
        public delegate void LecturertListHandler(object source, LecturerListHandlerEventArgs args);
        public event LecturertListHandler LecturersCountChanged;
        public event LecturertListHandler LecturerReferenceChanged;
        


        private System.Collections.Generic.List<Lecturer> _lecturers;
        public string NameOfList { get; set; }


        public LecturerCollection()
        {
            _lecturers = new List<Lecturer>();
        }


        public void AddDefaults()
        {
            Lecturer lecturer = new Lecturer("PZ", 10, Post.Bachelor, new Person("Dmitro", "Petrov", new DateTime(2000, 10, 10)));
            _lecturers.Add(lecturer);
            LecturersCountChanged?.Invoke(this, new LecturerListHandlerEventArgs(NameOfList, "Добавлен", lecturer));
        }


        public void AddLecturer(params Lecturer[] list)
        {
            if (list == null)
            {
                list = new Lecturer[0];
            }
            for (int i = 0; i < list.Length; i++)
            {
                _lecturers.Add(list[i]);
                LecturersCountChanged?.Invoke(this, new LecturerListHandlerEventArgs(NameOfList, "Добавлен", list[i]));
            }
        }


        public override string ToString()
        {
            string list = "";
            for(int i = 0; i < _lecturers.Count; i++)
            {
                list += _lecturers[i].ToString();
            }
            return "Список:\n"+list+"\n\n";
        }


        public string ToShortString()
        {
            string list = "";
            for (int i = 0; i < _lecturers.Count; i++)
            {
                list += _lecturers[i].ToShortString();
            }
            return "List:\n" + list;
        }


        public void SortSurnames()
        {
            _lecturers.Sort();
        }


        public void SortDateOfBirthd()
        {
            _lecturers.Sort(new Person());
        }   


        public void SortRaitings()
        {
            _lecturers.Sort(new RaitingSearch());
        }

        public bool Remove(int j)
        {
            if (j > _lecturers.Count) { return false; }
            else {
                LecturersCountChanged?.Invoke(this, new LecturerListHandlerEventArgs(NameOfList, "Удален", _lecturers[j]));
                _lecturers.RemoveAt(j);               
                return true;
            }
        }

        public Lecturer this[int index]
        {
            get { return _lecturers[index]; }
            set {
                _lecturers[index] = value;
                LecturerReferenceChanged?.Invoke(this, new LecturerListHandlerEventArgs(NameOfList, "Изменен", _lecturers[index]));
            }
        }
    }
}
