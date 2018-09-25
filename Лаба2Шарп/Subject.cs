using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public class Subject
    {
        public string NameOfSubject { get; set; }
        public string Shifr { get; set; }
        public int AmountOfhours { get; set; }
        public Subject(string name, string shifr, int hours)
        {
            NameOfSubject = name;
            Shifr = shifr;
            AmountOfhours = hours;
        }
        public Subject()
        {
            NameOfSubject = "Programming";
            Shifr = "PZ";
            AmountOfhours = 1;
        }
        public override string ToString()
        {
            return "\nYour subject is: " + NameOfSubject + " in '" +
                Shifr + "' about " +
                AmountOfhours + " hours";
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Subject))
                return false;
            else
                if (this.NameOfSubject == ((Subject)obj).NameOfSubject && this.Shifr == ((Subject)obj).Shifr && this.AmountOfhours == ((Subject)obj).AmountOfhours)
                return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Subject subject1, Subject subject2)
        {
            return subject1.Equals(subject2);
        }
        public static bool operator !=(Subject subject1, Subject subject2)
        {
            return subject1.Equals(subject2);
        }
        public object DeepCopy()
        {
            return new Subject { NameOfSubject = this.NameOfSubject, AmountOfhours = this.AmountOfhours, Shifr = this.Shifr };
        }
    }
}
