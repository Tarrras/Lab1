using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public enum Action {Add,Remove,Property};
    public delegate void LecturerChangedHandler<TKey>(object source, LectrurersChangedEventArgs<TKey> args);

    public class Lecturer : Person, IDataAndCopy,IEnumerable,INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;


        private string kafedra;
        private Post inform;
        private int rait;
        private List<Subject> subjects;
        private List<Theme> themes;
        public Lecturer(string kaf, int raiting, Post ekez,Person person):base(person.Name,person.Surname,person.Date)
        {
            subjects = new List<Subject>();
            themes = new List<Theme>();
            Kafedra = kaf;
            Raiting = raiting;
            Doljnost = ekez;
        }
        public DateTime Date { get; set; }
        public Lecturer():base()
        {
            subjects = new List<Subject>();
            themes=new List<Theme>();
            Doljnost = Post.Bachelor;
            Kafedra = "primat";
            Raiting = 8;
        }

        public string Kafedra
        {
            get { return kafedra; }
            set
            {
                kafedra = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Кафедра"));
            }
        }

        public Post Doljnost
        {
            get { return inform; }
            set
            {
                inform = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Должность"));
            }
        }

        public int Raiting
        {
            get { return rait; }
            set
            {
                if(value<=0 | value > 500)
                {
                    throw new System.Exception("Wrong result!");
                }
                else
                {
                    rait = value;
                }     
            }
        }
        public Person GetPerson
        {
            get { return new Person(base.name, base.surname, base.time); }
            set
            {
                base.name = value.Name;
                base.surname = value.Surname;
                base.time = value.Date;
            }
        }
        int sum = 0;

        

        public int FullTime
        {
            get
            {

                for (int i = 0; i < subjects.Count; i++)
                {
                    sum += subjects[i].AmountOfhours;
                }
                return sum;
            }
        }
        public void AddSubjects(params Subject[] list)
        {

            if (list == null)
            {
                list = new Subject[0];
            }
            for(int i = 0; i < list.Length; i++)
            {
                subjects.Add(list[i]); 
            }
        }
        public System.Collections.Generic.List<Theme> GetThemes
        {
            get {return themes; }
            set {themes=value; }
        }
        public System.Collections.Generic.List<Subject> GetSubject
        {
            get { return subjects; }
            set { subjects = value; }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Object> GetEnumerator()
        {
            foreach(Subject subject in subjects)
            {
                yield return subjects;
            }
            foreach (Theme theme in themes)
            {
                yield return theme;
            }
        }
        public IEnumerable<Subject> GetEnumeratorOfSubject(int hours)
        {
            foreach(Subject subject in subjects)
            {
                if (subject.AmountOfhours < hours)
                {
                    yield return subject;
                }
            }
        }
        public override string ToString()
        {
            string predm = "";
            for (int i = 0; i < subjects.Count; i++)
            {
                predm += subjects[i].ToString();
            }
            string predm2 = "";
            for (int i = 0; i < themes.Count; i++)
            {
                predm2 += themes[i].ToString();
            }
            return String.Format("Fio:"+base.ToString()+ "\nKafedra: " + Kafedra + "\nInform: " +
                inform + "" +
                    "\nrait: " + rait+"\nVremya: " + FullTime + "\nPredmetu: " +predm+"\nDiplomnue robotu: "+predm2+"\n\n");
        }

        public override string ToShortString()
        {
            return "FIO: "+Name  + "\nkafedra: " + kafedra + "\nInform: " +
                inform + "" +
                    "\nrait: " + rait + "\nVremya: "+FullTime ;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Lecturer))
                return false;
            else
                if (this.Kafedra == ((Lecturer)obj).Kafedra && this.Doljnost == ((Lecturer)obj).Doljnost && this.Raiting == ((Lecturer)obj).Raiting && this.GetPerson==((Lecturer)obj).GetPerson && this.FullTime==((Lecturer)obj).FullTime && this.GetThemes==((Lecturer)obj).GetThemes)
                return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Lecturer lecturer1, Lecturer lecturer2)
        {
            return lecturer1.Equals(lecturer2);
        }
        public static bool operator !=(Lecturer lecturer1, Lecturer lecturer2)
        {
            return !lecturer1.Equals(lecturer2);
        }
        public override object DeepCopy()
        {
            Lecturer obj = new Lecturer(Kafedra, Raiting, Doljnost, GetPerson);
            foreach(var i in subjects)
            {
                obj.subjects.Add((Subject)i.DeepCopy());
            }
            foreach (var i in themes)
            {
                obj.themes.Add((Theme)i.DeepCopy());
            }
            return obj;
        }


        

    }
}
