using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net1
{
    interface ILog<out T> where T: Client
    {
        event Action<TextWriter, T, Event> Log;
    }
}
