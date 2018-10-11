using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public Dictionary<TKey, Lecturer> keyValuePairs;
        private System.Collections.Generic.List<JournalEntry> _lecturers;
        public string NameOfList { get; set; }


        public LecturerCollection()
        {
            keyValuePairs = new Dictionary<TKey, Lecturer>();
            _lecturers = new List<JournalEntry>();
        }

        public void LecturerChangedIn(object sender,PropertyChangedEventArgs e)
        {
            TKey key = keyValuePairs.FirstOrDefault(i => i.Value.Equals(sender)).Key;
            //_lecturers.Add(new JournalEntry(NameOfList, Action.Property, e.PropertyName, key.ToString()));
            LecturersChanged?.Invoke(this, new LectrurersChangedEventArgs<TKey>(NameOfList, Action.Property, e.PropertyName, key));
        }

        public void AddDefaults(TKey key)
        {
            Lecturer lecturer = new Lecturer("PZ", 10, Post.Bachelor, new Person("Dmitro", "Petrov", new DateTime(2000, 10, 10)));
            lecturer.PropertyChanged +=this.LecturerChangedIn;
            keyValuePairs.Add(key, lecturer);
            LecturersChanged?.Invoke(this, new LectrurersChangedEventArgs<TKey>(NameOfList,Action.Add," ",key));
        }


        public void AddLecturer(TKey key,Lecturer list)
        {
            keyValuePairs.Add(key, list);
            list.PropertyChanged +=this.LecturerChangedIn;
            LecturersChanged?.Invoke(this, new LectrurersChangedEventArgs<TKey>(NameOfList,Action.Add," ",key));
        }

        public Lecturer this[TKey key]
        {
            
            get {
                try
                {
                    return keyValuePairs[key];
                }
                catch(Exception e)
                {
                    throw new Exception(e.ToString());
                }
            }
            set
            {
                try
                {
                    keyValuePairs[key] = value;
                    LecturersChanged?.Invoke(this, new LectrurersChangedEventArgs<TKey>(NameOfList, Action.Property, " ", key));
                }
                catch (Exception e)
                {
                    throw new Exception(e.ToString());
                }
            }
        }

        public bool Remove(Lecturer lecturer)
        {
            if (!keyValuePairs.ContainsValue(lecturer)) return false;
            else
            {
                foreach (var item in keyValuePairs.Where(kpv => kpv.Value.Equals(lecturer)).ToList())
                {
                    TKey key = item.Key;
                    keyValuePairs.Remove(key);
                    item.Value.PropertyChanged -= this.LecturerChangedIn;
                    LecturersChanged?.Invoke(this, new LectrurersChangedEventArgs<TKey>(NameOfList, Action.Remove, " ", key));
                }
                return true;
            }
        }


        //public override string ToString()
        //{
        //    string list = "";
        //    for(int i = 0; i < lecturers.Count; i++)
        //    {
        //        list += _lecturers[i].ToString();
        //    }
        //    return "Список:\n"+list+"\n\n";
        //}


        //public string ToShortString()
        //{
        //    string list = "";
        //    foreach(var v in keyValuePairs)
        //    {
        //        list += v.Value + " " + v.Key + "\n";
        //    }
        //    return "List:\n" + list;
        //}


        //public void SortSurnames()
        //{
        //    _lecturers.Sort();
        //}


        //public void SortDateOfBirthd()
        //{
        //    _lecturers.Sort(new Person());
        //}   


        //public void SortRaitings()
        //{
        //    _lecturers.Sort(new RaitingSearch());
        //}

        //public bool Remove(int j)
        //{
        //    if (j > _lecturers.Count) { return false; }
        //    else {
        //        LecturersChanged?.Invoke(this, new LecturerListHandlerEventArgs(NameOfList, "Удален", _lecturers[j]));
        //        _lecturers.RemoveAt(j);               
        //        return true;
        //    }
        //}



        //public IEnumerable<Lecturer> GetLecturers()
        //{
        //    SortRaitings();
        //    return _lecturers;
        //}


    }
}
