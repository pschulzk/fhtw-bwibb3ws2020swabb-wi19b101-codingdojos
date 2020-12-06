using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dojo_02.ViewModel
{
    class Person
    {
        public DateTime Birthdate { set; get; }
        public string Firstname { set; get; }
        public string Lastname { set; get; }
        public int SSN { set; get; }

        public Person(DateTime birthdate, string firstname, string lastname, int sSN)
        {
            Birthdate = birthdate;
            Firstname = firstname;
            Lastname = lastname;
            SSN = sSN;
        }

    }
}
