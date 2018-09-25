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
        public string TypeOfNewElement { get; set; }
        public string NewElementOfList { get; set; }
        public JournalEntry(string NameOfCollection, string TypeOfNewElement, string NewElementOfList)
        {
            this.NameOfCollection = NameOfCollection;
            this.TypeOfNewElement = TypeOfNewElement;
            this.NewElementOfList = NewElementOfList;
        }
        public override string ToString()
        {
            return "1." + NameOfCollection + "\n" +
                "2." + TypeOfNewElement + "\n" +
                "3." + NewElementOfList + "\n";
        }
    }
}
