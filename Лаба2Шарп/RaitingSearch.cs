using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public class RaitingSearch:IComparer<Lecturer>
    {
        public int Compare(Lecturer obj1,Lecturer obj2)
        {
            Lecturer lec1 = obj1 as Lecturer;
            Lecturer lec2 = obj2 as Lecturer;
            if (lec1 != null && lec2 != null)
            {
                if (lec1.Raiting > lec2.Raiting) return 1;
                else if (lec1.Raiting < lec2.Raiting) return -1;
                else return 0;
            }
            else throw new Exception("Imposible");
        }
    }
}
