using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public enum Post {Specialist,Bachelor,SecondEducation};
    class Program
    {
        static void Main(string[] args)
        {
            int[] keys = {100,10,130,13,2,25,104};
            LecturerCollection<string> collection1=new LecturerCollection<string>();
            LecturerCollection<string> collection2 = new LecturerCollection<string>();
            collection1.NameOfList = "collection1";
            collection2.NameOfList = "collection2";
            Journal<string> journal = new Journal<string>();
            collection1.LecturersChanged += journal.LecturerChanged;
            collection2.LecturersChanged += journal.LecturerChanged;

            
            Lecturer lecturer1 = new Lecturer("peimat", keys[0], Post.Specialist, new Person("Petro", "Petrov", new DateTime()));
            Lecturer lecturer2 = new Lecturer("peimat", keys[1], Post.Specialist, new Person("Petro", "Petrov", new DateTime()));
            Lecturer lecturer3 = new Lecturer("peimat", keys[2], Post.Specialist, new Person("Petro", "Petrov", new DateTime()));
            Lecturer lecturer4 = new Lecturer("peimat", keys[3], Post.Specialist, new Person("Petro", "Petrov", new DateTime()));
            Lecturer lecturer5 = new Lecturer("peimat", keys[4], Post.Specialist, new Person("Petro", "Petrov", new DateTime()));
            Lecturer lecturer6 = new Lecturer("peimat", keys[5], Post.Specialist, new Person("Petro", "Petrov", new DateTime()));
            Lecturer lecturer7 = new Lecturer("peimat", keys[6], Post.Specialist, new Person("Petro", "Petrov", new DateTime()));


            collection1.AddLecturer(keys[0].ToString(), lecturer1);
            collection1.AddLecturer(keys[1].ToString(), lecturer2);
            collection1.AddLecturer(keys[2].ToString(), lecturer3);
            collection1.AddLecturer(keys[3].ToString(), lecturer4);
            collection1.AddLecturer(keys[4].ToString(), lecturer5);
            collection1.AddLecturer(keys[5].ToString(), lecturer6);
            collection1.AddLecturer(keys[6].ToString(), lecturer7);


            collection2.AddLecturer("21", new Lecturer());


            collection1["130"].Kafedra = "KAFEDRA";

            List<Lecturer> lecturers = new List<Lecturer>();
           
            
            collection1.Remove(lecturer2);


            Console.WriteLine(journal);
            string res = " ";
            lecturers = collection1.SoringDictionary();
            for (int i = 0; i < lecturers.Count; i++)
            {
                res += lecturers[i].ToShortString()+$"\nKey:{keys[i]}\n\n";
            }

            

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
