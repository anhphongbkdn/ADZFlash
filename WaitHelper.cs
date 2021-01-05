using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADZFlash
{
    class WaitHelper
    {
        public static void ForMiliSeconds(int milisecondTimeout)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(milisecondTimeout));
        }

        public static void ForSecond(int secondTimeout)
        {
            Thread.Sleep(TimeSpan.FromSeconds(secondTimeout));
        }
    }
}
