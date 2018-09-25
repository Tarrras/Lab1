using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    public class Theme
    {
        public string Tema { get; set; }
        public bool Choose { get; set; }
        public Theme()
        {
            Tema = "algebra";
            Choose = false;
        }
        public Theme(string tema,bool choose)
        {
            Tema = tema;
            Choose = choose;
        }
        public override string ToString()
        {
            return Tema + " is " + Choose;
        }
        public object DeepCopy()
        {
            return new Theme { Tema = this.Tema, Choose = this.Choose };
        }
    }
}
