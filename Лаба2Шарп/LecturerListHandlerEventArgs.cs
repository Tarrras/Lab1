namespace Лаба2Шарп
{
    public class LecturerListHandlerEventArgs:System.EventArgs
    {
        public string GetList { get; set; }
        public string GetTypes { get; set; }
        public Lecturer GetNewLecturer { get; set; }
        public LecturerListHandlerEventArgs() { }       
        public LecturerListHandlerEventArgs(string listName,string typesName,Lecturer lecturer) {
            GetNewLecturer = lecturer;
            GetList = listName;
            GetTypes=typesName;
        }       
        public override string ToString()
        {
            return " 1." + GetList+"\n"
                + "2." + GetTypes+"\n"
                + "3." + GetNewLecturer + "\n";
        }

    }
}