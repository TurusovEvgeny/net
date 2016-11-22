using System;
using System.Collections.Generic;
using System.IO;

namespace net1
{
    class Client : IAccount<IComponent>, IClonable
    {
        private int _sum; // Переменная для хранения суммы
        private int _bonus; // Переменная для хранения процента

        public event Action<Event> _Put;
        public event Action<Event> _Withdraw;

        public List<IComponent> components = new List<IComponent>();

        private static string name_file;
        private static int sum_file;
        private static int bonus_file;

        public string Name { get; set; }// Имя клиента

        public Client(string name, int sum, int bonus)
        {
            Name = name;
            _sum = sum;
            _bonus = bonus;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public int CurrentSum
        {
            get { return _sum; }
        }
        /// <summary>
        /// Считывание данных из файла
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Client FromFile(string path)
        {
            var inf = File.ReadAllLines(path);

            try
            {
                name_file = inf[0];
                sum_file = Convert.ToInt32(inf[1]);
                bonus_file = Convert.ToInt32(inf[2]);
            }
            catch (FormatException)
            { throw new FileFormatException("Неверный формат входного файла."); }

            return new Client(name_file, sum_file, bonus_file);
        }

        public void Put(int sum)
        {
            if (sum <= 0)
                throw new ClientException("Сумма должна быть положительной.");
            _Put.Invoke(new Event(Doing.Put));
            _sum += sum;
        }

        public void Withdraw(int sum)
        {
            if (sum > _sum)
                throw new ClientException("Сумма должна быть меньше либо равна сумме счета.");
            _Withdraw.Invoke(new Event(Doing.Withdraw));
            if (sum <= _sum)
            {
                _sum -= sum;
            }
        }

        public int Bonus
        {
            get { return _bonus; }
        }

        public virtual void Display()
        {
            Console.WriteLine(Name + " " + _sum + " " + _bonus);
        }

        public List<IComponent> ReturnObject()
        {
            return components;
        }

        public void SetComponent(IComponent comp)
        {
            components.Add(comp);
        }
    }
}
