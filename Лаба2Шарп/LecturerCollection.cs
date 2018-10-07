using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public class LecturerCollection<TKey>:Lecturer
    {
        public delegate void LecturertListHandler(object source, LecturerListHandlerEventArgs args);
        public event LecturertListHandler LecturersCountChanged;
        public event LecturertListHandler LecturerReferenceChanged;

        public event LecturerChangedHandler<TKey> LecturersChanged;

        private Dictionary<TKey, Lecturer> keyValuePairs;
        private System.Collections.Generic.List<Lecturer> _lecturers;
        public string NameOfList { get; set; }


        public LecturerCollection()
        {
            keyValuePairs = new Dictionary<TKey, Lecturer>();
           // _lecturers = new List<Lecturer>();
        }


        public void AddDefaults(TKey key)
        {
            Lecturer lecturer = new Lecturer("PZ", 10, Post.Bachelor, new Person("Dmitro", "Petrov", new DateTime(2000, 10, 10)));
            keyValuePairs.Add(key, lecturer);
            LecturersChanged?.Invoke(this, new LectrurersChangedEventArgs<TKey>(NameOfList,Action.Add," ",key));
        }


        public void AddLecturer(params KeyValuePair<TKey,Lecturer>[] list)
        {
            if (list == null)
            {
                list = new KeyValuePair<TKey, Lecturer>[0];
            }
            for (int i = 0; i < list.Length; i++)
            {
                keyValuePairs.Add(list[i].Key, list[i].Value);
                LecturersChanged?.Invoke(this, new LectrurersChangedEventArgs<TKey>(NameOfList,Action.Add," ",list[i].Key));
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
                LecturersChanged?.Invoke(this, new LecturerListHandlerEventArgs(NameOfList, "Удален", _lecturers[j]));
                _lecturers.RemoveAt(j);               
                return true;
            }
        }

        public Lecturer this[int index]
        {
            get { return _lecturers[index]; }
            set {
                _lecturers[index] = value;
                LecturersChanged?.Invoke(this, new LecturerListHandlerEventArgs(NameOfList, "Изменен", _lecturers[index]));
            }
        }

        public bool Remove(Lecturer lecturer)
        {
            if (!keyValuePairs.ContainsValue(lecturer)) return false;
            else
            {
                foreach (var item in keyValuePairs.Where(kpv => kpv.Value == lecturer).ToList())
                {
                    keyValuePairs.Remove(item.Key);
                }
                return true;
            }
        }

        public IEnumerable<Lecturer> GetLecturers()
        {
            SortRaitings();
            return _lecturers;
        }


    }
}
