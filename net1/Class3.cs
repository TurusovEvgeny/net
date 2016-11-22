using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net1
{
    class Clerc : Person
    {
        public string Bank { get; set; }

        public Clerc(string fName, string lName, string company)
            : base(fName, lName)
        {
            Bank = company;
        }

        public override void Display()
        {
            Console.WriteLine(FirstName + " " + LastName + " работает в банке " + Bank);
        }
    }
}
