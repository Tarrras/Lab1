using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Шарп
{
    interface IDataAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
}
