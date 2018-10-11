using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public class JournalEntry
    {
        public string NameOfCollection { get; set; }
        public Action GetAction { get; set; }
        public string GetLecturer { get; set; }
        public string GetTKey { get; set; }
        public JournalEntry(string NameOfCollection, Action GetAction, string GetLecturer,string GetTKey)
        {
            this.NameOfCollection = NameOfCollection;
            this.GetAction = GetAction;
            this.GetLecturer = GetLecturer;
            this.GetTKey = GetTKey;
        }
        public override string ToString()
        {
            return "1." + NameOfCollection + "\n" +
                "2." + GetAction + "\n" +
                "3." + GetLecturer + "\n" +
                "4." + GetTKey + "\n\n";
        }
    }
}
