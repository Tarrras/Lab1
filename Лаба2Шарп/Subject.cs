using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    [Serializable]
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
            Subject subject = new Subject(NameOfSubject, Shifr, AmountOfhours);
            MemoryStream ms = new MemoryStream();
            try
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Subject));
                jsonSerializer.WriteObject(ms, subject);
                ms.Position = 0;
                subject= jsonSerializer.ReadObject(ms) as Subject;
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                subject = null;
            }
            return subject;
        }
    }
}
