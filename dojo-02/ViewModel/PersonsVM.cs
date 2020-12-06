using dojo_02.ViewModel;
using Dojo3Help.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo4.ViewModel
{
    public class PersonVM : BaseViewModel
    {

        private Person person;

        #region PROPERTIES
        public DateTime Birthdate
        {
            get { return person.Birthdate; }
            set { person.Birthdate = value; RaisePropertyChanged(); }
        }

        public String Firstname
        {
            get { return person.Firstname; }
            set { person.Firstname = value; RaisePropertyChanged(); }
        }

        public String Lastname
        {
            get { return person.Lastname; }
            set { person.Lastname = value; RaisePropertyChanged(); }
        }

        public int SSN
        {
            get { return person.SSN; }
            set { person.SSN = value; RaisePropertyChanged(); }
        }
        #endregion

        public PersonVM(string lastname, string firstname, DateTime birthdate, int ssn)
        {
            this.person = new Person(birthdate, firstname, lastname, ssn);
        }
        
        // public Person ConvertBack()
        // {
        //    return person;
        // }

    }
}
