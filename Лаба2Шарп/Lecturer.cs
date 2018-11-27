using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Лаба2Шарп
{
    public enum Action {Add,Remove,Property};
    public delegate void LecturerChangedHandler<TKey>(object source, LectrurersChangedEventArgs<TKey> args);
    [Serializable]
    public class Lecturer : Person, IDataAndCopy,IEnumerable,INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;


        private string kafedra;
        private Post inform;
        private int rait;
        private List<Subject> subjects;

        public Lecturer(string kaf, int raiting, Post ekez,Person person):base(person.Name,person.Surname,person.Date)
        {
            subjects = new List<Subject>();
            Kafedra = kaf;
            Raiting = raiting;
            Doljnost = ekez;
        }
        public DateTime Date { get; set; }
        public Lecturer():base()
        {
            subjects = new List<Subject>();
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
            return String.Format("Fio:"+base.ToString()+ "\nKafedra: " + Kafedra + "\nInform: " +
                inform + "" +
                    "\nrait: " + rait + "\nPredmetu: " +predm+"\n");
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
                if (this.Kafedra == ((Lecturer)obj).Kafedra && this.Doljnost == ((Lecturer)obj).Doljnost && this.Raiting == ((Lecturer)obj).Raiting && this.GetPerson==((Lecturer)obj).GetPerson && this.FullTime==((Lecturer)obj).FullTime )
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


        private static IFormatter formatter = new BinaryFormatter();
        public new Lecturer DeepCopy()
        {

            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(stream) as Lecturer;
            }
        }

        public bool Save(string filename)
        {
            if (!File.Exists($"{filename}.dat"))
            {
                Console.WriteLine("Файла с таким именем не обнаруженно. Файл создан");
            }
            try
            {
                using (FileStream fs = new FileStream($"{filename}.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, this);
                    fs.Close();
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());                
                return false;
            }
            return true;
        }

        public bool Load(string filename)
        {
            Lecturer lecturer;
            try
            {
                using (FileStream fs = new FileStream($"{filename}.dat", FileMode.Open))
                {
                    lecturer=formatter.Deserialize(fs) as Lecturer;
                    fs.Close();
                }
            }catch(Exception e)
            {
                Console.WriteLine("\n ЗАГРУЖАЕМЫЙ ФАЙЛ ПУСТОЙ!");
                return false;
            }

            this.Kafedra = lecturer.Kafedra;
            this.Raiting = lecturer.Raiting;
            this.Doljnost = lecturer.Doljnost;
            this.GetPerson = lecturer.GetPerson;
            this.GetSubject = lecturer.GetSubject;
            return true;
        }

        public bool AddFromConsole()
        {
            string text="";
            text += "Введите значения для полей обьекта\n";
            text += "Доступные для использования разделители: \" \" , \"-\" , \",\" \n";
            text += "[Название предмета] [Группа] [Кол-во часов]";
            Console.WriteLine(text);
            string[] data = Console.ReadLine().Split(' ', ',', '-');
            int hour;
            try
            {
                hour = int.Parse(data[2]);
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            try
            {
                Subject subject = new Subject(data[0], data[1], hour);
                GetSubject.Add(subject);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Вы ввели неправильные данные!");
                return false;
            }            
        }

        public static bool Save(string filename, Lecturer obj)
        {
            try
            {
                if (!File.Exists($"{filename}.dat"))
                {
                    Console.WriteLine("Файла с таким именем не обнаруженно. Файл создан");
                }
                using (FileStream fs = new FileStream($"{filename}.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, obj);
                    fs.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public static bool Load(string filename, Lecturer obj)
        {
            Lecturer lecturer;
            try
            {
                using (FileStream fs = new FileStream($"{filename}.dat", FileMode.OpenOrCreate))
                {
                    lecturer = formatter.Deserialize(fs) as Lecturer;
                    fs.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            obj.Kafedra = lecturer.Kafedra;
            obj.Raiting = lecturer.Raiting;
            obj.Doljnost = lecturer.Doljnost;
            obj.GetPerson = lecturer.GetPerson;
            obj.GetSubject = lecturer.GetSubject;
            return true;
        }
    }
}
