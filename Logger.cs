using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADZFlash
{
    public class Logger
    {
        public delegate void PrintLog(string log);
        public static PrintLog print;
    }
}
