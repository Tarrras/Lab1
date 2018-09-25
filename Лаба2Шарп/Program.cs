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
            Console.WriteLine("\n\n\nFIRST COLLECTION:\n");
            LecturerCollection lecturerCollection = new LecturerCollection();
            lecturerCollection.NameOfList = "lecturerCollection";
            Lecturer lecturer=new Lecturer("---AA---", 10,Post.Bachelor,new Person());
            Subject subject = new Subject("History", "PS", 10);
            Theme theme = new Theme("Proga", false);
            lecturer.GetThemes.Add(theme);
            lecturer.AddSubjects(subject);  
            lecturerCollection.AddLecturer(lecturer);

            Lecturer lecturer1 = new Lecturer("---BB---", 12, Post.SecondEducation, new Person("Ptro", "KIDs", new DateTime(2000, 05, 22)));
            Subject subject1 = new Subject("Program", "PZ", 15);
            Theme theme1 = new Theme();
            lecturer1.AddSubjects(subject1);
            lecturer1.GetThemes.Add(theme1);
            lecturerCollection.AddLecturer(lecturer1);

            Lecturer lecturer2 = new Lecturer("---CC---", 5, Post.Specialist, new Person("Hello","Worl",new DateTime(1999,05,22)));
            Subject subject2 = new Subject("Math", "WL", 11);
            Theme theme2 = new Theme("Kursach", false);
            lecturer2.GetThemes.Add(theme2);
            lecturer2.AddSubjects(subject2);
            lecturerCollection.AddLecturer(lecturer2);

            Console.WriteLine(lecturerCollection.ToString());

            Console.WriteLine("\n\n\nSECOND COLLECTION:\n");
            LecturerCollection lecturerCollection1 = new LecturerCollection();
            lecturerCollection1.NameOfList = "lecturerCollection1";
            Lecturer lecturer1_1 = new Lecturer("---DD---", 10, Post.Bachelor, new Person());
            Subject subject1_1 = new Subject("Philosophy", "PS", 10);
            Theme theme1_1 = new Theme("Proga", false);
            lecturer1_1.GetThemes.Add(theme1_1);
            lecturer1_1.AddSubjects(subject1_1);
            lecturerCollection1.AddLecturer(lecturer1_1);

            Lecturer lecturer1_2 = new Lecturer("---EE---", 12, Post.SecondEducation, new Person("Ptro", "KIDs", new DateTime(2000, 05, 22)));
            Subject subject1_2 = new Subject("Alghoritms", "PZ", 15);
            Theme theme1_2 = new Theme();
            lecturer1_2.AddSubjects(subject1_2);
            lecturer1_2.GetThemes.Add(theme1_2);
            lecturerCollection1.AddLecturer(lecturer1_2);

            Lecturer lecturer1_3 = new Lecturer("---FF---", 5, Post.Specialist, new Person("Hello", "Worl", new DateTime(1999, 05, 22)));
            Subject subject1_3 = new Subject("OS", "WL", 11);
            Theme theme1_3 = new Theme("Kursach", false);
            lecturer1_3.GetThemes.Add(theme1_3);
            lecturer1_3.AddSubjects(subject1_3);
            lecturerCollection1.AddLecturer(lecturer1_3);
            Console.WriteLine(lecturerCollection1.ToString());


            Console.WriteLine("------------------------\n");


            Journal journal1 = new Journal();
            Journal journal2 = new Journal();


            lecturerCollection.LecturersCountChanged+= journal1.AddCountChanget;
            lecturerCollection.LecturerReferenceChanged+= journal1.AddTypeChanged;


            lecturerCollection.LecturerReferenceChanged += journal2.AddCountChanget;
            lecturerCollection1.LecturerReferenceChanged += journal2.AddCountChanget;
            //Add elemnts

            Lecturer lecturer4 = new Lecturer("---FF---", 5, Post.Specialist, new Person("Hello", "Hello", new DateTime(1999, 09, 09)));
            Subject subject4= new Subject("Hello", "Hello", 11);
            Theme theme4 = new Theme("Hello", false);
            lecturer4.GetThemes.Add(theme4);
            lecturer4.AddSubjects(subject4);
            lecturerCollection.AddLecturer(lecturer4);
            lecturerCollection1.AddLecturer(lecturer4);
            Console.WriteLine(lecturerCollection.ToString());
            Console.WriteLine("\n\n\n");
            Console.WriteLine(lecturerCollection1.ToString());
            Console.WriteLine("\n\n\n");
            Console.WriteLine(journal1);
            Console.WriteLine("------------------------\n");

            Console.WriteLine(journal2);
            //Remove elemnets
            Console.WriteLine("REMOVE---------------");
            Console.WriteLine("Input element's id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            bool isDeleted, isDeleted1;
            isDeleted = lecturerCollection.Remove(id);
            isDeleted1 = lecturerCollection1.Remove(id);
            if (!isDeleted || !isDeleted1){ Console.WriteLine("Error"); }
            else
            {
                Console.WriteLine(lecturerCollection.ToString());
                Console.WriteLine("\n\n\n");
                Console.WriteLine(lecturerCollection1.ToString());
                Console.WriteLine("\n\n\n");

                Console.WriteLine(journal1);
                Console.WriteLine("------------------------\n");
                Console.WriteLine(journal2);
            }

            //Changed
            Console.WriteLine("CHANGED------------");
            Console.WriteLine("\nInput element's id: ");
            int id1 = Convert.ToInt32(Console.ReadLine());
            Lecturer lecturer5 = new Lecturer("---XXX---", 5, Post.Specialist, new Person("---XXX---", "---XXX---", new DateTime(1999, 09, 09)));
            Subject subject5 = new Subject("---XXX---", "---XXX---", 11);
            Theme theme5 = new Theme("---XXX---", false);
            lecturer5.GetThemes.Add(theme5);
            lecturer5.AddSubjects(subject5);
            lecturerCollection[id1] = lecturer5;
            lecturerCollection1[id1] = lecturer5;
            Console.WriteLine(lecturerCollection.ToString());
            Console.WriteLine("\n\n\n");
            Console.WriteLine(lecturerCollection1.ToString());
            Console.WriteLine("\n\n\n");

            Console.WriteLine(journal1);
            Console.WriteLine("------------------------\n");
            Console.WriteLine(journal2);
            Console.ReadLine();
        }
    }
}
