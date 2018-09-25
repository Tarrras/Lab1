using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public class TestCollections:Lecturer
    {
        private List<Person> _person ;
        private List<string> _names ;
        private Dictionary<Person, Lecturer> _keyValuePairs;
        private Dictionary<string, Lecturer> _keyStringPairs;
        public static Lecturer Reference(int num)
        {
            Lecturer lecturer=new Lecturer($"{num}",num,Post.Bachelor,new Person($"{num}",$"{num}",new DateTime()));
            /*if (!_person.Contains(lecturer))
            {
                _person.Add(lecturer as Person);
                _names.Add(lecturer.ToString());
                _keyValuePairs.Add(lecturer as Person, lecturer);
                _keyStringPairs.Add(lecturer.ToString(), lecturer);
            }*/
            return lecturer;
        }
        public TestCollections(int num)
        {
            _person = new List<Person>();
            _names = new List<string>();
            _keyValuePairs = new Dictionary<Person, Lecturer>();
            _keyStringPairs = new Dictionary<string, Lecturer>();
            for (int i = 1; i < num+1; i++)
            {
                 _person.Add(Reference(i).GetPerson);
                 _names.Add(Reference(i).GetPerson.ToString());
                 _keyValuePairs.Add(Reference(i).GetPerson, Reference(i));
                 _keyStringPairs.Add(Reference(i).GetPerson.ToString(), Reference(i));
                
            }
        }
        public string TimeOfSearch(int num)
        {
            Lecturer rt = Reference(num);
            string info = "";
            bool temp;
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            //Person temp1 =rt as Person;
            temp = _person.Contains(rt.GetPerson);
            Console.WriteLine(temp);
            time.Stop();
            info += String.Format("Время поиска элемента в List<Person> - {0}\n", time.Elapsed);
            time.Reset();

            time.Start();
            //string temp2 = rt.ToString();
            temp = _names.Contains(rt.GetPerson.ToString());
            Console.WriteLine(temp);
            time.Stop();
            info += String.Format("Время поиска элемента в List<string> - {0}\n", time.Elapsed);
            time.Reset();

            time.Start();
            temp = _keyValuePairs.ContainsKey(rt.GetPerson);
            Console.WriteLine(temp);
            time.Stop();
            info += String.Format("Время поиска по ключу в Dictionary<Person,Lecturer> - {0}\n", time.Elapsed);
            time.Reset();

            time.Start();
            temp = _keyValuePairs.ContainsValue(rt);
            Console.WriteLine(temp);
            time.Stop();
            info += String.Format("Время поиска по значению в Dictionary<Person,Lecturer> - {0}\n", time.Elapsed);
            time.Reset();

            time.Start();
            temp = _keyStringPairs.ContainsKey(rt.GetPerson.ToString());
            Console.WriteLine(temp);
            time.Stop();
            info += String.Format("Время поиска по ключу в Dictionary<string,Lecturer> - {0}\n", time.Elapsed);
            time.Reset();

            time.Start();
            temp = _keyStringPairs.ContainsValue(rt);
            Console.WriteLine(temp);
            time.Stop();
            info += String.Format("Время поиска по значению в Dictionary<string,Lecturer> - {0}\n", time.Elapsed);

            return info;


        }

    }
}
