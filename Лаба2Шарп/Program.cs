using System;
using System.Collections.Generic;
using System.IO;
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
            Lecturer lecturer = new Lecturer("ПЗ", 10, Post.Specialist, new Person("Иван", "Андреев", new DateTime(2000, 12, 12)));
            lecturer.AddSubjects(new Subject("Матан", "ПЗ-1", 15));
            Lecturer lecturer1 = lecturer.DeepCopy();


            Console.WriteLine(lecturer.ToString()+"\n");
            Console.WriteLine(lecturer1.ToString()+"\n");

            link:
            Console.WriteLine("Введи имя файла: ");
            string filename = Console.ReadLine();
            
            if (!File.Exists($"{filename}.dat"))
            {
                Console.WriteLine("Файла не существует, файл создан");
                File.Create($"{filename}.dat").Close();
                goto link;
            }
            else
            {
                lecturer.Load(filename);
                Console.WriteLine("\n" + lecturer.ToString() + "\n");
            }

            lecturer.AddFromConsole();
            lecturer.Save(filename);

            Console.WriteLine("\n" + lecturer.ToString() + "\n");

            Lecturer.Load(filename, lecturer);

            lecturer.AddFromConsole();

            Lecturer.Save(filename, lecturer);

            Console.WriteLine("Окончательный результат #1");
            Console.WriteLine("\n" + lecturer.ToString() + "\n");


            Console.ReadLine();
        }
    }
}
