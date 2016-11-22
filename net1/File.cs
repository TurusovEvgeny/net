using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace net1
{
    class File<T>: ILog<T> where T: Client
    {
        public event Action<TextWriter, T, Event> Log;

        private T client;

        private string file;

        public File(T _client, string _file)
        {
            client = _client;
            file = _file;
            client._Put += clientEvent;
            client._Withdraw += clientEvent;

            if (!File.Exists(file))
            {
                var fs = File.Create(file);
                fs.Close();
            }

        }

        private void clientEvent(Event args)
        {
            using (var writer = File.AppendText(file))
            {
                Log?.Invoke(writer, client, args);
            }
        }
    }
}
