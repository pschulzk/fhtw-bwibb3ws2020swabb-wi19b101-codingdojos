using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ExerciseSimpleMultiVM.ViewModel
{
    public class PersonVm : ViewModelBase
    {

        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public int SSN { get; set; }
        public string Description { get; set; }
        public BitmapImage Image { get; set; }

        public PersonVm(string lastname, string firstname, int sSN, string description, BitmapImage image)
        {
            Lastname = lastname;
            Firstname = firstname;
            SSN = sSN;
            Description = description;
            Image = image;
        }
        public PersonVm()
        {
            Lastname = "";
            Firstname = "";
            SSN = 0;
            Description = "";

        }

        public PersonVm Clone()
        {
            if (Image != null)
                return new PersonVm(this.Lastname, this.Firstname, this.SSN, this.Description, new BitmapImage(new Uri(this.Image.UriSource.ToString())));
            else return new PersonVm(this.Lastname, this.Firstname, this.SSN, this.Description, null);
        }
    }
}
