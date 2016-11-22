using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace net1
{
    class Console<T>: ILog<T> where T: Client
    {
        public event Action<TextWriter, T, Event> Log;

        private T client;

        public Console(T _client)
        {
            client = _client;
            client._Put += clientEvent;
            client._Withdraw += clientEvent;
        }

        private void clientEvent(Event args)
        {
            using (var writer = Console.Out)
            {
                Log?.Invoke(writer, client, args);
            }
        }
    }
}
