using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net1
{
    class Manager : Boss
    {
        public Manager(string fName, string lName, int sal) 
            : base(fName, lName, sal)
        {
            Salary = sal - 500;
        }
    }
}
