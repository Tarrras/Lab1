using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public class Person:IDataAndCopy,IComparable, IComparer<Person>
    {
        protected string name;
        protected string surname;
        protected System.DateTime time;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public DateTime Date
        {
            get { return time; }
            set { time = value; }
        }
        public int Changed_Year
        {
            get { return time.Year; }
            set { time = new DateTime(value, time.Month, time.Day, time.Hour, time.Minute, time.Second); }
        }
        public Person(string imya, string familiya, DateTime times)
        {
            Name = imya;
            Surname = familiya;
            Date = times;
        }
        public Person()
        {
            Name = "Ivan";
            Surname = "Ivanon";
            time = new DateTime(2000, 01, 01, 5, 5, 15);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Person))
                return false;
            else
                if (this.Name == ((Person)obj).Name && this.Surname == ((Person)obj).Surname && this.Date == ((Person)obj).Date)
                return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator == (Person person1,Person person2)
        {
            return person1.Equals(person2);
        }
        public static bool operator !=(Person person1, Person person2)
        {
            return !person1.Equals(person2);
        }
        public virtual object DeepCopy()
        {
            return new Person { Name = this.Name, Surname = this.Surname, Date = this.Date };
        }
        public override string ToString()
        {
            return "Your name is " + Name + " " + Surname +
                "\nAnd born " + Date;
        }
        public virtual string ToShortString()
        {
            return Name + " " + Surname;
        }

        public int CompareTo(Object obj)
        {
            Person p = obj as Person;
            if (p != null)
            {
                return string.Compare(this.Surname, p.Surname);
            }
            else throw new Exception("Imposible");
        }
        public int Compare(Person obj1,Person obj2)
        {
            Person p1 = obj1 as Person;
            Person p2 = obj2 as Person;
            if (p1 != null && p2 != null)
            {
                if (p1.Date > p2.Date) return 1;
                else if (p1.Date < p2.Date) return -1;
                else return 0;
            }
            else throw new Exception("Imposible");
        }
    }
}
