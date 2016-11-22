using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net1
{
    abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
        }

        public abstract void Display(); 
    }
}
