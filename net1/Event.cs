using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net1
{
    public enum Doing
    {
        Put,
        Withdraw
    }

    class Event
    {
        public Doing type;
        public Event(Doing doing)
        {
            type = doing;
        }
    }
}
