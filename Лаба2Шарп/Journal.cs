using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public class Journal<TKey>
    {
        private List<JournalEntry> _journalEntries;

        public Journal()
        {
            _journalEntries = new List<JournalEntry>();
        }


        public override string ToString()
        {
            string list = "";
            for (int i = 0; i < _journalEntries.Count; i++)
            {
                list += _journalEntries[i];
            }
            return "Cобытия: \n" +
                list + "\n";
        }


        public void LecturerChanged(object sender, LectrurersChangedEventArgs<TKey> e)
        {
            _journalEntries.Add(new JournalEntry(e.GetNameOfCollection, e.GetAction, e.GetLecturer, e.GetKey.ToString()));
        }

       
    }
}
