using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public class Journal
    {
        public List<JournalEntry> _journalEntries;

        public Journal()
        {
            _journalEntries = new List<JournalEntry>();     
        }


        public override string ToString()
        {
            string list = "";
            for(int i=0;i< _journalEntries.Count; i++)
            {
                list += _journalEntries[i];
            }
            return "Cобытия: \n"+
                list+"\n";
        }


        public void AddTypeChanged(object sender, LecturerListHandlerEventArgs e)
        {
            _journalEntries.Add(new JournalEntry(e.GetList,e.GetTypes,e.GetNewLecturer.ToString()));
        }


        public void AddCountChanget(object sender, LecturerListHandlerEventArgs e)
        {
            _journalEntries.Add(new JournalEntry(e.GetList, e.GetTypes, e.GetNewLecturer.ToString()));
        }
    }
}
