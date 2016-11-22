using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net1
{
    class ProClient : Client
    {
        public ProClient(string name, int sum, int bonus) : base(name, sum, bonus)
        {}
        public override void Put(int sum)
        {
            base.Put(sum);
            sum += Bonus;
        }
        public override void Display()
        {
            Console.WriteLine("Клиент " + Name + " имеет счет на сумму " + CurrentSum + ": Pro клиент");
        }
    }
}
