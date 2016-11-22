using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net1
{
    class Boss : Person
    {
        public int Salary { get; set; }

        public Boss(string fName, string lName, int sal)
                : base(fName, lName)
        {
            Salary = sal;
        }

        public override void Display()
        {
            Console.WriteLine(FirstName + " " + LastName + " получает зарплату " + Salary);
        }
    }
}
