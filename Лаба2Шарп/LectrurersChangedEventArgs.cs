using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public class LectrurersChangedEventArgs<TKey> : System.EventArgs
    {
        public string GetNameOfCollection { get; set; }
        public Action GetAction { get; set; }
        public string GetLecturer { get; set; }
        public TKey GetKey { get; set; }
        public LectrurersChangedEventArgs(string getNameOfCollection,Action getAction,string getLecturer,TKey getKey)
        {
            GetNameOfCollection = getNameOfCollection;
            GetAction = getAction;
            GetLecturer = getLecturer;
            GetKey = getKey;
        }

        public LectrurersChangedEventArgs()
        {
        }

        public override string ToString()
        {
            return "WTF:\n" +
                GetNameOfCollection + "\n" +
                GetAction + "\n" +
                GetLecturer + "\n" +
                GetKey + "\n";
        }
    }
}
