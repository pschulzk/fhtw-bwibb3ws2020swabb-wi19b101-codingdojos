using GalaSoft.MvvmLight;

namespace exercise_04.ViewModel
{
    public class AnimalVm : ViewModelBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Family { get; set; }
        public string Habitate { get; set; }

        private bool eatsMeat;

        public bool EatsMeat
        {
            get { return eatsMeat; }
            set { eatsMeat = value; RaisePropertyChanged(); }
        }

        public int Population { get; set; }
        public AnimalVm(string name, int age, string family, string habitate, bool eatsMeat, int population)
        {
            Name = name;
            Age = age;
            Family = family;
            Habitate = habitate;
            EatsMeat = eatsMeat;
            Population = population;
        }
    }
}
