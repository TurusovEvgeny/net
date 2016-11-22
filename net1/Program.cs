using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace net1
{
    class Program
    {
        static void Main(string[] args)
        {
            clientGroup<Client> group = new clientGroup<Client>(interflow);
            Client client1 = new Client("Женя", 200, 10);
            Client client2 = new Client("Миша", 500, 0);
            Client client3 = new Client("Вася", 350, 50);
            group.Add(client1);
            group.Add(client2);
            group.Add(client3);
            Client clientf = Client.FromFile("client.txt");
            clientf.Display();
            
            try
            {
                clientf.Put(0);
            }
            catch (UserException er)
            {
                ExceptionsLogger.LogUserException(er);
            }
            catch (Exception er)
            {
                ExceptionsLogger.LogSystemException(er);
            }

            try
            {
                clientf.Withdraw(125);
            }
            catch (UserException er)
            {
                ExceptionsLogger.LogUserException(er);
            }
            catch (Exception er)
            {
                ExceptionsLogger.LogSystemException(er);
            }

            var cons = new Console<Client>(client1);
            var file = new File<Client>(client1, "log1.txt");
            cons.Log += LogWriter;
            file.Log += LogWriter;
            client1.Put(200);
            client1.Withdraw(20);
            client1.Put(50);


            /*foreach (Client c in group)
            {
                c.Display();
            }

            group.Sort();   
            Console.WriteLine("---");
            foreach (Client c in group)
            {
                c.Display();
            }*/
            //Console.WriteLine("Invocation list has {0} methods.", cons.GetInvocationList().Length);
            Console.ReadLine();
        }  
            
        public static List<Client> interflow(List<Client> objects)
                {
                    if (objects.Count == 1)
                        return objects;
                    int mid = objects.Count / 2;
                    return merge(interflow(objects.Take(mid).ToList()), interflow(objects.Skip(mid).ToList()));
                }

        public static List<Client> merge(List<Client> obj1, List<Client> obj2)
                {
                    int a = 0, b = 0;
                    Client[] merged = new Client[obj1.Count + obj2.Count];
            for (int i = 0; i < obj1.Count + obj2.Count; i++)
                 {
                     if (b < obj2.Count && a < obj1.Count)
                         if (obj1[a].CurrentSum > obj2[b].CurrentSum && b < obj2.Count)
                             merged[i] = obj2[b++];
                         else
                             merged[i] = obj1[a++];
                     else
                         if (b < obj2.Count)
                         merged[i] = obj2[b++];
                     else
                         merged[i] = obj1[a++];
                 }
                 return merged.ToList();
            }

        public static void LogWriter(TextWriter writer, Client client, Event doing)
        {
            string message = "";
            switch (doing.type)
            {
                case Doing.Put:
                    message = "Клиент банка: " + client.Name + ", пополнил счет.";
                    break;
                case Doing.Withdraw:
                    message = "Клиент банка: " + client.Name + ", снял деньги со счета.";
                    break;
            }
            writer.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " " + message);
        }

    }
}